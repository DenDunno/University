using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Parcs
{
    public interface IJob // объект  — задача
    {
        int Number { get; }

        //IList<string> FileNames { get; }
        IPoint CreatePoint(int parentNumber);
        bool AddFile(string fileName);
        string FileName { get; }
        void FinishJob();
        bool IsFinished { get; }
    }
}
