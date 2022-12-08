using NewMatrixModule;

namespace MatrixGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(args[0]);
            int w = int.Parse(args[1]);
            new Matrix(h, w, true).WriteToFile(args.Length > 2 ? args[2] : "matrix.mtr");
        }
    }
}
