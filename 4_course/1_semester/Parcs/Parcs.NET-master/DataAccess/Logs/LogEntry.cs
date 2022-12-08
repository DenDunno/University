using System;

namespace DataAccess.Logs
{
    public class LogEntry
    {
        public long LogEntryId { get; set; }
        
        public string UserName { get; set; }

        public DateTime DateTimeUtc { get; set; }

        public string Thread { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }
    }
}
