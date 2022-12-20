using DbmsEmulator.Constants;
using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DbmsService _dbmsService;

        public DatabaseController(DbmsService dbmsService) =>
            _dbmsService = dbmsService;

        [HttpPost()]
        [Route("create/{dbname}")]
        public IActionResult Create([FromRoute] string dbName)
        {
            Database database = new(dbName);

            ValidationService validationService = new(database);
            validationService.ValidateModel();

            _dbmsService.CreateDatabase(database);

            return Ok(string.Format(ResponseMessages.DatabaseCreated, dbName));
        }
    }
}