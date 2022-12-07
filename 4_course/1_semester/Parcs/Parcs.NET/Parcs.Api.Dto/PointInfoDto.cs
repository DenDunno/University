using System;

namespace Parcs.Api.Dto
{
    public class PointInfoDto
    {
        public int Number { get; set; }
        public string HostIpAddress { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartTimeUtc { get; set; }
        public DateTime? FinishTimeUtc { get; set; }
    }
}
