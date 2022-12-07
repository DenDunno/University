using Parcs;
using System.Threading;

namespace NewMatrixModule
{
    public class MultMatrix : IModule
    {
        public void Run(ModuleInfo info, CancellationToken token = default(CancellationToken))
        {
            Matrix m = (Matrix)info.Parent.ReadObject(typeof(Matrix));
            Matrix m1 = (Matrix)info.Parent.ReadObject(typeof(Matrix));
            info.Parent.WriteObject(m.MultiplyBy(m1, token));
        }
    }
}
