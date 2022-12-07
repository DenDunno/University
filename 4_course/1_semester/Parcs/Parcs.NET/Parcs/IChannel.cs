using System;

namespace Parcs
{
    public interface IChannel 
    {
        void WriteData(bool data);
        void WriteData(byte data);
        void WriteData(int data);
        void WriteData(long data);
        void WriteData(double data);
        void WriteData(string data);
        bool ReadBoolean();
        byte ReadByte();
        int ReadInt();
        long ReadLong();
        double ReadDouble();
        string ReadString();
        void WriteObject(object obj);
        object ReadObject();
        void WriteFile(string filePath);
        string ReadFile();
        int From { get; set; }
        object ReadObject(Type type);
        T ReadObject<T>();
        void Close();
    }
}
