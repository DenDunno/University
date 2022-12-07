using System.IO;


namespace Parcs
{
    public class Point : IPoint
    {
        public HostInfo Host { get; private set; }
        private IChannel _channel;
        private readonly IJob _job;
        public int Number { get; private set; }
        private readonly int _parentNumber;

        public Point(IJob job, int parentNumber)
        {
            _job = job;
            _parentNumber = parentNumber;

            Initialize();
        }

        protected virtual void Initialize()
        {
            HostInfo serv = Job.Server;
            string ipAddress = null;
            if (serv.IsConnected || serv.Connect())
            {
                serv.Writer.Write((byte) Constants.PointCreated);
                serv.Writer.Write(_job.Number);
                serv.Writer.Write(_parentNumber);

                ipAddress = ReadIPFromStream(serv.Reader);
                Host = new HostInfo(ipAddress, (int)Ports.DaemonPort);
                if (!Host.Connect())
                {
                    throw new ParcsException("Cannot connect to host");
                }
            }
        }

        protected virtual IChannel CreateNewChannel()
        {
            return new Channel(Host.Reader, Host.Writer) { From = Number };
        }


        public virtual IChannel CreateChannel()
        {
            _channel = CreateNewChannel();
            InitializeChannel();

            return _channel;
        }

        public virtual void ExecuteClass(string className)
        {
            _channel.WriteData((byte)Constants.ExecuteClass);
            _channel.WriteData(className);
        }

        private void InitializeChannel()
        {
            _channel.WriteData((byte)Constants.RecieveTask);
            _channel.WriteObject(_job);
            WriteNumberToChannel();
            string fileName = _job.FileName;
            if (fileName != null)
            {
                _channel.WriteData((byte)Constants.LoadFile);
                _channel.WriteFile(fileName);
            }
        }

        protected virtual void WriteNumberToChannel()
        {
            Host.Writer.Write(Number); //to wrap it with continuewith
        }

        private string ReadIPFromStream(BinaryReader binaryReader)
        {
            Number = binaryReader.ReadInt32();
            return binaryReader.ReadString();
        }

    }
}