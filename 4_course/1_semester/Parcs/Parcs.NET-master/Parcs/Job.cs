using System;
using System.IO;

namespace Parcs
{
    [Serializable]
    public class Job : IJob
    {
        private static HostInfo _server;
        public static HostInfo Server
        {
            get
            {
                if (_server == null)
                {
                    _server = ReadServerName();
                }

                return _server;
            }
            private set { _server = value; }
        }

        private const string serverName = "server.txt";

        public string FileName
        {
            get;
            private set;
        }

        public int Number { get; }

        public bool IsFinished { get; private set; }

        public Job() : this(0, string.Empty)
        {
        }

        public Job(int priority, string username)
        {
            if (!Server.IsConnected && !Server.Connect()) throw new Exception("Cannot connect to server...");
            var writer = Server.Writer;

            writer.Write((byte)Constants.BeginJob);
            writer.Write(priority);
            writer.Write(username);
            Number = Server.Reader.ReadInt32();
        }

        public static void SetServerIp(string serverIp)
        {
            Server = new HostInfo(serverIp, (int)Ports.ServerPort);
        }

        private static HostInfo ReadServerName()
        {
            try
            {

                using (StreamReader reader = new StreamReader(serverName))
                {
                    var serverIp = reader.ReadLine();
                    return new HostInfo(serverIp, (int)Ports.ServerPort);
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("File " + serverName + " was not found");
                return null;
            }

            catch (IOException)
            {
                Console.WriteLine("Can not read from file " + serverName);
                return null;
            }
        }

        public void FinishJob()
        {
            if (!IsFinished)
            {
                Server.Writer.Write((byte)Constants.FinishJob);
                Server.Writer.Write(Number);
                IsFinished = true;
            }
        }

        public IPoint CreatePoint(int parentNumber)
        {
            return new ConcurrentPoint(this, parentNumber);
        }

        public bool AddFile(string fileName)
        {
            if (FileName == fileName) { return true; }
            if (File.Exists(fileName))
            {
                FileName = fileName;
                return true;
            }

            return false;
        }
    }
}
