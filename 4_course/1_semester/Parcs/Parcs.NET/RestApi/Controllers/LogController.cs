using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using DataAccess.Logs;

namespace RestApi.Controllers
{
    [AllowAnonymous]
    public class LogController : ODataController
    {
        private readonly ILogEntryRepository _repository;

        public LogController(ILogEntryRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        [EnableQuery(PageSize = 100)]
        public IQueryable<LogEntry> Get()
        {
            return _repository.Get().OrderByDescending(item => item.DateTimeUtc);
        }
    }
}