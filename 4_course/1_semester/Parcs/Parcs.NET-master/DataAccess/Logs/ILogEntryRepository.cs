using System.Linq;

namespace DataAccess.Logs
{
    public interface ILogEntryRepository
    {
        IQueryable<LogEntry> Get();
    }

}
