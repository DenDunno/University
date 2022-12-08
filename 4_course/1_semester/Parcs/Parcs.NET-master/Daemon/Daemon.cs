using System;
using System.Net;
using System.Net.Sockets;
using Parcs;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using Serilog;

namespace DaemonPr
{
    public class Daemon : ServiceBase
    {
        TcpListener _listener;
        private readonly object _locker = new object();
        private readonly ConcurrentDictionary<int, List<int>> _jobPointNumberDictionary = new ConcurrentDictionary<int, List<int>>(); //stores numbers of points
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _cancellationDictionary = new ConcurrentDictionary<int, CancellationTokenSource>();
        static HostInfo _server;
        private static ILogger _log;
        private const string LocalIpArgument = "--localIp";
        private const string ExternalLocalIpArgument = "--externalLocalIp";
        private const string HostServerIpArgument = "--hostServerIp";
        private static string _hostServerIp;

        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(() => Run(args, false));
        }

        protected override void OnStop()
        {
            _listener.Stop();
        }

        public void Run(string[] args, bool allowUserInput)
        {
            string localIp = Environment.GetEnvironmentVariable(EnvironmentVariables.LocalIp)
                ?? ExtractFromArgs(args, LocalIpArgument);

            _hostServerIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostServerAddress)
                ?? ExtractFromArgs(args, HostServerIpArgument);

            IPAddress ip = string.IsNullOrEmpty(localIp) ? HostInfo.GetLocalIpAddress(allowUserInput) : IPAddress.Parse(localIp);

            HostInfo.ExternalLocalIP = Environment.GetEnvironmentVariable(EnvironmentVariables.ExternalLocalIp)
                ?? ExtractFromArgs(args, ExternalLocalIpArgument)
                ?? ip.ToString();

            int port = (int)Ports.DaemonPort;
            _listener = new TcpListener(ip, port);
            TryConnectToHostServer();
            _log.Information($"Accepting connections from clients, IP: {ip}, port: {port}");
            RunListener();   
        }

        private static void TryConnectToHostServer()
        {
            if (!string.IsNullOrWhiteSpace(_hostServerIp))
            {
                int serverPort = (int) Ports.ServerPort;

                _log.Information($"Connecting to Host Server, IP: {_hostServerIp}, port: {serverPort}");

                _server = new HostInfo(_hostServerIp, serverPort);
                if (_server.Connect())
                {
                    _server.SendLocalIp();
                }
            }
            else
            {
                _log.Warning($"Environment Variable {EnvironmentVariables.HostServerAddress} is not set");
            }
        }

        private void RunListener()
        {
            _listener.Start();
            while (true)
            {
                try
                {
                    var client = _listener.AcceptTcpClient();
                    var clientStream = client.GetStream();

                    var clientTask = new Task(() => RunClient(clientStream));
                    clientTask.Start();

                }
                catch (SocketException e)
                {
                    _log.Error(e, "Stopping the listener...");
                    _listener.Stop();
                    return;
                }
            }
        }

        private void RunClient(NetworkStream clientStream)
        {
            using (BinaryReader reader = new BinaryReader(clientStream))
            {
                using (BinaryWriter writer = new BinaryWriter(clientStream))
                {
                    Channel channel = new Channel(reader, writer);
                    Job currentJob = null;
                    int pointNumber = 0;

                    while (true)
                    {
                        try
                        {
                            byte signal = channel.ReadByte();

                            switch (signal)
                            {
                                case ((byte)Constants.RecieveTask):

                                    currentJob = (Job)channel.ReadObject();
                                    pointNumber = channel.ReadInt();
                                    _jobPointNumberDictionary.AddOrUpdate(currentJob.Number, new List<int> { pointNumber },
                                        (key, oldvalue) =>
                                        {
                                            lock (oldvalue) oldvalue.Add(pointNumber);
                                            return oldvalue;
                                        });
                                    _cancellationDictionary.AddOrUpdate(currentJob.Number, new CancellationTokenSource(),
                                        (key, oldValue) => oldValue);
                                    continue;

                                case ((byte)Constants.ExecuteClass):

                                    if (currentJob != null)
                                    {
                                        var cancellationTokenSource = _cancellationDictionary[currentJob.Number];
                                        if (!_cancellationDictionary[currentJob.Number].IsCancellationRequested)
                                        {
                                            var executor = new ModuleExecutor(channel, currentJob, pointNumber);

                                            try
                                            {
                                                executor.Run(cancellationTokenSource.Token);
                                            }
                                            catch (OperationCanceledException)
                                            {
                                                _log.Information($"Point N {currentJob.Number}:{pointNumber} was cancelled");
                                            }

                                            DeletePoint(currentJob.Number, pointNumber);

                                            if (_jobPointNumberDictionary[currentJob.Number].Count == 0)
                                            {
                                                lock (_locker)
                                                {
                                                    if (File.Exists(currentJob.FileName))
                                                    {
                                                        File.Delete(currentJob.FileName);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    return;

                                case ((byte)Constants.LoadFile):
                                    {
                                        LoadFile(channel, currentJob);
                                        continue;
                                    }

                                case ((byte)Constants.ProcessorsCountRequest):
                                    {
                                        channel.WriteData(Environment.ProcessorCount);
                                        continue;
                                    }

                                case ((byte)Constants.LinpackRequest):
                                    {
                                        var linpack = new Linpack();
                                        linpack.RunBenchmark();
                                        channel.WriteData(linpack.MFlops);
                                        continue;
                                    }

                                case ((byte)Constants.IpAddress):
                                    {
                                        string ip = channel.ReadString();
                                        if (_server == null || !_server.IsConnected)
                                        {
                                            _server = new HostInfo(ip, (int)Ports.ServerPort);
                                            if (!_server.Connect())
                                            {
                                                TryConnectToHostServer();
                                            }
                                            else
                                            {
                                                _hostServerIp = ip;
                                            }
                                        }

                                        continue;
                                    }
                                case ((byte)Constants.CancelJob):
                                {
                                    int jobNumber = channel.ReadInt();
                                    CancellationTokenSource tokenSource;
                                    if (_cancellationDictionary.TryGetValue(jobNumber, out tokenSource))
                                    {
                                        tokenSource.Cancel();
                                        _log.Information($"Cancelling job N {jobNumber}");
                                    }
                                    else
                                    {
                                        _log.Information($"Job N {jobNumber} does not exist or does not have cancellation token");
                                    }
                                    continue;
                                }

                                default:
                                    _log.Warning($"Unknown signal received: {signal}");
                                    return;
                            }
                        }

                        catch (Exception ex)
                        {
                            Log.Error(ex, ex.Message);
                            return;
                        }
                    }
                }
            }
        }

        private void LoadFile(IChannel channel, IJob curJob)
        {
            string fileName = channel.ReadFile();

            if (!curJob.AddFile(fileName))
            {
                throw new ParcsException("File was not sent");
            }
        }

        private void DeletePoint(int jobNum, int pointNum)
        {
            _jobPointNumberDictionary.AddOrUpdate(jobNum, new List<int>(), (key, oldvalue) =>
            {
                lock(oldvalue) oldvalue.Remove(pointNum);
                return oldvalue;
            });

            if (_server != null)
            {
                if (_server.IsConnected || _server.Connect())
                {
                    _server.Writer.Write((byte)Constants.PointDeleted);
                    _server.Writer.Write(jobNum);
                    _server.Writer.Write(pointNum);
                }
            }
        }

        public static void Main(string[] args)
        {
            LogConfigurator.Configure();
            _log = Log.Logger.ForContext<Daemon>();

            using (var daemon = new Daemon())
            {
                if (!Environment.UserInteractive && !args.Contains("--docker"))
                {
                    // running as service
                    ServiceBase.Run(daemon);
                }

                else
                {
                    // running as console app
                    string localIp = Environment.GetEnvironmentVariable(EnvironmentVariables.LocalIp);

                    daemon.Run(args, true);
                }
            }
        }

        private static string ExtractFromArgs(string[] args, string argName)
        {
            int localIpIndex = Array.FindIndex(args, arg => arg.Equals(argName, StringComparison.OrdinalIgnoreCase));
            return localIpIndex == -1 ? null : args[localIpIndex + 1];
        }
    }

}
