using Parcs.Module.CommandLine;

namespace NewMatrixModule
{
    using CommandLine;

    public class CommandLineOptions : BaseModuleOptions
    {
        [Option("m1", Required = true, HelpText = "File path to the first matrix.")]
        public string File1 { get; set; }
        [Option("m2", Required = true, HelpText = "File path to the second matrix.")]
        public string File2 { get; set; }
        [Option("p", Required = true, HelpText = "Number of points.")]
        public int PointsNum { get; set; }        
    }
}
