namespace Parcs.Api.Dto
{
    public class HostInfoDto
    {
        public string IpAddress { get; set; }
        public int PointCount { get; set; }
        public int ProcessorCount { get; set; }
        public double LinpackResult { get; set; }
        public bool IsConnected { get; set; }
    }
}
