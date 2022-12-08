using System;
using System.Text;
using System.Reflection;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Parcs
{
    public class Channel : IChannel
    {
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private static readonly object SyncRoot = new object();

        public int From { get; set; }

        public int Index { get; set; } = -1;
        public void WriteData(bool data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public void WriteData(byte data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public void WriteData(int data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public void WriteData(long data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public void WriteData(double data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public void WriteData(string data)
        {
            _writer.Write(data);
            _writer.Flush();
        }

        public Channel(BinaryReader reader, BinaryWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        public byte ReadByte()
        {
            return _reader.ReadByte();
        }

        public int ReadInt()
        {
            return _reader.ReadInt32();
        }

        public long ReadLong()
        {
            return _reader.ReadInt64();
        }

        public double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        public string ReadString()
        {
            return _reader.ReadString();
        }
        
        public virtual void WriteObject(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.ToArray();
                byte[] byteObject = memoryStream.ToArray();
                _writer.Write(byteObject.Length);
                _writer.Write(byteObject);
                // _writer.Flush();
            }

        }
        public object ReadObject()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return ReadObject(formatter);
        }

        public object ReadObject(Type type)
        {
            BinaryFormatter formatter = new BinaryFormatter { Binder = new MySerializationBinder(type) };
            return ReadObject(formatter);
        }

        public T ReadObject<T>()
        {
            return (T) ReadObject(typeof (T));
        }

        private object ReadObject(BinaryFormatter formatter)
        {
            int numberOfBytes = _reader.ReadInt32();
            byte[] obj = _reader.ReadBytes(numberOfBytes);
            object o;
            using (MemoryStream memoryStream = new MemoryStream(obj))
            {
                o = formatter.Deserialize(memoryStream);
            }

            return o;
        }

        public virtual void WriteFile(string fullPath)
        {
            byte[] file = File.ReadAllBytes(fullPath);
            //_writer.Write((new FileInfo(fullPath)).Name);
            _writer.Write(file.Length);
            _writer.Write(file);
            _writer.Flush();
        }

        public virtual string ReadFile()//сохраняет файл в хранилище.
        {
            //string fileName = _reader.ReadString();
            int fileSize = _reader.ReadInt32();
            byte[] file = _reader.ReadBytes(fileSize);
            string fileName = GetHashedFileName(file);
            
            IsolatedStorageFile userFile = IsolatedStorageFile.GetUserStoreForAssembly();

            if (!userFile.FileExists(fileName))
            {
                lock (SyncRoot)
                {
                    if (!userFile.FileExists(fileName))
                    {
                        IsolatedStorageFileStream isolatedStream = new IsolatedStorageFileStream(fileName, FileMode.Create, userFile);
                        BinaryWriter writer = new BinaryWriter(isolatedStream);
                        writer.Write(file);

                        writer.Close();
                        isolatedStream.Close();
                    }
                }
            }

            return userFile.GetType().GetField("m_RootDir", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(userFile).ToString() + "\\" + fileName;
            
        }

        public virtual void Close()
        {
            if (_reader != null)
            {
                _reader.Close();
            }

            if (_writer != null)
            {
                _writer.Close();
            }
        }

        private string GetHashedFileName(byte[] file)
        {
            return ByteArrayToString(GetHash(file));
        }

        private byte[] GetHash(byte[] data)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(data);
            }
        }

        private string ByteArrayToString(byte[] byteArray)
        {
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        private class MySerializationBinder : SerializationBinder
        {
            private Type _type;

            public MySerializationBinder(Type type)
            {
                _type = type;
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                return Assembly.GetAssembly(_type).GetType(typeName);
            }
        }

    }
}
