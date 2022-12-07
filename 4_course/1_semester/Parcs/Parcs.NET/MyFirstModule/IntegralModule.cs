using System;
using System.Threading;
using Parcs;

namespace FirstModule
{
    public class IntegralModule: IModule
    {
        private static double Integral(double a, double b, double h, Func<double, double> func)
        {
            int N = (int)((b - a) / h);
            double res = 0;
            for (int j = 1; j <= N; ++j)
            {
                double x = a + (2 * j - 1) * h / 2;
                res += func(x);
            }

            return res * h;
        }

        public void Run(ModuleInfo info, CancellationToken token = default(CancellationToken))
        {
            double a = info.Parent.ReadDouble();
            double b = info.Parent.ReadDouble();
            double h = info.Parent.ReadDouble();
            var func = new Func<double, double>(x => Math.Cos(x));

            double res = Integral(a, b, h, func);
            info.Parent.WriteData(res);
        }
    }
}
