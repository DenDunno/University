using DbmsEmulator.Constants;
using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DbmsService _dbmsService;

        public DatabaseController(DbmsService dbmsService)
        {
            _dbmsService = dbmsService;
        }

        [HttpPost()]
        [Route("create/{dbname}")]
        public IActionResult Create([FromRoute] string dbName)
        {
            _dbmsService.CreateDatabase(dbName);

            return Ok(string.Format(ResponseMessages.DatabaseCreated, dbName));
        }

        [HttpDelete()]
        [Route("drop/{dbname}")]
        public IActionResult Drop([FromRoute] string dbName)
        {
            _dbmsService.DropDatabase(dbName);

            return Ok(string.Format(ResponseMessages.DatabaseDropped, dbName));
        }

        [HttpPost()]
        [Route("save/{dbname}")]
        public IActionResult Save([FromRoute] string dbName)
        {
            DatabaseModel database = _dbmsService.TryGetDatabase(dbName);

            FileService.Write(database);

            return Ok(string.Format(ResponseMessages.DatabaseSaved, dbName));
        }

        [HttpGet()]
        [Route("get/{dbname}")]
        [ResponseType(typeof(DatabaseModel))]
        public IActionResult GetTable([FromRoute] string dbName)
        {
            DatabaseModel database = FileService.Read(dbName);

            return Ok(database);
        }
    }
}