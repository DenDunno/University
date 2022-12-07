using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Parcs
{
    public class HostInfo
    {
        public IPAddress IpAddress
        {
            get;
        }

        public int Port
        {
            get; private set;
        }


        private TcpClient _tcpClient;
        private NetworkStream _stream;

        public BinaryReader Reader { get; private set; }
        public BinaryWriter Writer { get; private set; }

        public bool IsConnected
        {
            get { return _tcpClient != null && _tcpClient.Connected; }
        }

        public int PointCount { get; set; }
        public int ProcessorCount
        {
            get
            {
                if (_processorCount == null)
                {
                    _processorCount = GetProcessorCount();
                }

                return _processorCount.Value;
            }
        }

        public double LinpackResult
        {
            get
            {
                if (_linpackResult == null)
                {
                    _linpackResult = GetLinpackResult();
                }

                return _linpackResult.Value;
            }
        }

        private int? _processorCount;
        private double? _linpackResult;

        public bool Connect()
        {
            var ipEndPoint = new IPEndPoint(IpAddress, Port);
            if (_tcpClient == null || !_tcpClient.Connected)
            {
                _tcpClient = new TcpClient();
            }

            //int attemptsNumber = 10;
            //int i = 0;
            while (!_tcpClient.Connected)
            {
                try
                {
                    _tcpClient.Connect(ipEndPoint);
                    _stream = _tcpClient.GetStream();
                    //_stream.ReadTimeout = 20;
                    //networkStream = tcpClient.GetStream();
                    Reader = new BinaryReader(_stream);
                    Writer = new BinaryWriter(_stream);
                    Console.WriteLine("Connection to host (IP: {0}) is established", IpAddress.ToString());
                    return true;
                }

                catch (SocketException)
                {
                    Console.WriteLine("Cannot connect to host, IP: {0}", IpAddress.ToString());
                    return false;
                }
            }

            return true;

        }

        public HostInfo(string ipAddress, int port)
            : this(IPAddress.Parse(ipAddress), port)
        {
        }


        public HostInfo(IPAddress ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }

        public void SendLocalIp()
        {
            Writer.Write((byte)Constants.IpAddress);
            Writer.Write(ExternalLocalIP);
        }

        private int GetProcessorCount()
        {
            Writer.Write((byte)Constants.ProcessorsCountRequest);
            return Reader.ReadInt32();
        }

        private double GetLinpackResult()
        {
            Writer.Write((byte)Constants.LinpackRequest);
            return Reader.ReadDouble();
        }

        public static IPAddress LocalIP
        {
            get
            {
                if (_localIp != null)
                {
                    return _localIp;
                }
                string hostName = Dns.GetHostName();
                var ipHostEntry = Dns.GetHostEntry(hostName);

                return _localIp = ipHostEntry.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).Single(x => !IPAddress.IsLoopback(x) && !x.ToString().StartsWith("192.168.56"));
            }
        }

        public static string ExternalLocalIP
        {
            get { return _externalLocalIp ?? _localIp.ToString(); }
            set { _externalLocalIp = value; }
        }

        private static IPAddress _localIp;
        private static string _externalLocalIp;

        public static IPAddress GetLocalIpAddress(bool allowUserInput)
        {
            IPAddress ip;
            try
            {
                ip = HostInfo.LocalIP;
            }

            catch (Exception)
            {
                if (!allowUserInput)
                    throw;

                Console.WriteLine("Cannot get local IP. Please, enter your IP:");
                string ipStr = Console.ReadLine();
                ip = IPAddress.Parse(ipStr);
                _localIp = ip;
            }
            return ip;
        }
    }
}
