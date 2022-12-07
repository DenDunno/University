using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcs;

namespace HostServer
{
    public interface IPointInfo
    {
        int Number { get; set; }
        int ParentNumber { get; }
        HostInfo Host { get; }
        bool IsFinished { get; set; }
        DateTime StartTimeUtc { get; }
        DateTime? FinishTimeUtc { get; }
    }
}
