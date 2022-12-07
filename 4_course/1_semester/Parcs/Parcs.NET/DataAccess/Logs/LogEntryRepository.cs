using System.Linq;

namespace DataAccess.Logs
{
    public class LogEntryRepository : ILogEntryRepository
    {
        private readonly HostServerContext _context;

        public LogEntryRepository(string connectionString)
        {
            _context = new HostServerContext(connectionString);
        }
        
        public IQueryable<LogEntry> Get()
        {
            return _context.Logs;
        }
    }
}
