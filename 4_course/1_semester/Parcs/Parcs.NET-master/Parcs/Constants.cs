using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcs
{
    public enum Constants: byte
    {
        PointCreated = 0,
        PointDeleted = 1,
        RecieveTask = 2,
        LoadFile = 3,
        LoadClasses = 4,
        ExecuteClass = 5,
        ConnectPoint = 6, 
        BeginJob = 7,
        ProcessorsCountRequest = 8,
        FinishJob = 9,
        LinpackRequest = 10,
        IpAddress = 11,
        CancelJob = 12
    }
    public enum Ports
    {
        ServerPort = 1234,
        ServerWebApiPort = 1236,
        DaemonPort = 2222
    }
}
