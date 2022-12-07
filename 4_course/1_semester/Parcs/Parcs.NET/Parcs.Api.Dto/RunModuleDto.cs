namespace Parcs.Api.Dto
{
    public class RunModuleDto
    {
        public string Name { get; set; }
        public string CommandLineParameters { get; set; }
        public int Priority { get; set; }
    }
}
