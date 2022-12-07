using System;
using System.Collections.Generic;

namespace Parcs.Api.Dto
{
    public class JobInfoDto
    {
        public int Number { get; set; }
        public int Priority { get; set; }
        public string JobStatus {get;set;}
        public DateTime StartTimeUtc { get; set; }
        public DateTime? FinishTimeUtc { get; set; }
        public string Username { get; set; }
        public ICollection<PointInfoDto> Points { get; set; } 
    }
}
