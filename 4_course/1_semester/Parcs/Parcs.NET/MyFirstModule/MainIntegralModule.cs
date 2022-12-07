using System;
using System.Reflection;
using System.Threading;
using Parcs;

namespace FirstModule
{
    class MainIntegralModule: IModule
    {
        public static void Main(string[] args)
        {
            
            var job = new Job();
            if (!job.AddFile(Assembly.GetExecutingAssembly().Location/*"MyFirstModule.exe"*/))
            {
                Console.WriteLine("File doesn't exist");
                return;
            }

            (new MainIntegralModule()).Run(new ModuleInfo(job, null));
            Console.ReadKey();
        }

        public void Run(ModuleInfo info, CancellationToken token = default(CancellationToken))
        {
            double a = 0;
            double b = Math.PI/2;
            double h = 0.00000001;
            const int pointsNum = 2;
            var points = new IPoint[pointsNum];
            var channels = new IChannel[pointsNum];
            for (int i = 0; i < pointsNum; ++i)
            {
                points[i] = info.CreatePoint();
                channels[i] = points[i].CreateChannel();
                points[i].ExecuteClass("FirstModule.IntegralModule");
            }

            double y = a;
            for (int i = 0; i < pointsNum; ++i)
            {
                channels[i].WriteData(y);
                channels[i].WriteData(y + (b - a) / pointsNum);
                channels[i].WriteData(h);
                y += (b - a) / pointsNum;
            }
            DateTime time = DateTime.Now;            
            Console.WriteLine("Waiting for result...");

            double res = 0;
            for (int i = pointsNum - 1; i >= 0; --i)
            {
                res += channels[i].ReadDouble();
            }

            Console.WriteLine("Result found: res = {0}, time = {1}", res, Math.Round((DateTime.Now - time).TotalSeconds,3));
            
        }
    }
}
