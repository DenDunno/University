using System;

namespace Parcs
{
    internal class ConcurrentChannel : IChannel
    {
        volatile Channel _channel;

        internal ConcurrentChannel(IPoint point, TaskQueue taskQueue)
        {
            _taskQueue = taskQueue;
            _taskQueue.StartNewTask(() => CreateChannel(point));
        }

        private void CreateChannel(IPoint point)
        {
            _channel = new Channel(point.Host.Reader, point.Host.Writer) { From = _from };
        }
        

        public void Close()
        {
            _taskQueue.StartNewTask(() => _channel.Close());
        }

        public void WriteData(string data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data));
        }

        public bool ReadBoolean()
        {
            _taskQueue.Wait();
            return _channel.ReadBoolean();
        }

        public byte ReadByte()
        {
            _taskQueue.Wait();
            return _channel.ReadByte();
        }

        public int ReadInt()
        {
            _taskQueue.Wait();
            return _channel.ReadInt();
        }

        public long ReadLong()
        {
            _taskQueue.Wait();
            return _channel.ReadLong();
        }

        public double ReadDouble()
        {
            _taskQueue.Wait();
            return _channel.ReadDouble();
        }

        public string ReadString()
        {
            _taskQueue.Wait();
            return _channel.ReadString();
        }

        public void WriteFile(string fullPath)
        {
           _taskQueue.StartNewTask(() => _channel.WriteFile(fullPath));
        }

        public void WriteObject(object obj)
        {
           _taskQueue.StartNewTask(() => _channel.WriteObject(obj));
        }

        public string ReadFile()
        {
            _taskQueue.Wait();
            return _channel.ReadFile();
        }

        public object ReadObject()
        {
            _taskQueue.Wait();
            return _channel.ReadObject();
        }

        public object ReadObject(Type type)
        {
            _taskQueue.Wait();
            return _channel.ReadObject(type);
        }

        public T ReadObject<T>()
        {
            return (T) ReadObject(typeof (T));
        }

        private readonly TaskQueue _taskQueue;

        public bool Works
        {
            get { return true; }
        }

        public void WriteData(bool data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data)); ;
        }

        public void WriteData(byte data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data)); ;
        }

        public void WriteData(int data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data)); ;
        }

        public void WriteData(long data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data)); ;
        }

        public void WriteData(double data)
        {
            _taskQueue.StartNewTask(() => _channel.WriteData(data)); ;
        }

        public int From
        {
            get
            {
                if (_channel == null)
                {
                    return _from;
                }

                return _channel.From;
            }
            set
            {
                if (_channel == null)
                {
                    _from = value;
                }

                else
                {
                    _channel.From = value;
                }
            }
        }

        private int _from;
    }
}
