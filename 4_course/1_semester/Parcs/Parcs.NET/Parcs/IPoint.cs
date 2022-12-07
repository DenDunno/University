using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcs
{
    public interface IPoint
    {
        IChannel CreateChannel();
        void ExecuteClass(string className);
        HostInfo Host { get; }
        int Number { get; }
    }
}
