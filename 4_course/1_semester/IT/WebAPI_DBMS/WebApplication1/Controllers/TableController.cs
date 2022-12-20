using DbmsEmulator.Constants;
using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbmsEmulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly DbmsService _dbmsService;

        public TableController(DbmsService dbmsService) =>
            _dbmsService = dbmsService;

        [HttpPost()]
        [Route("create/in/{dbname}")]
        public IActionResult Create([FromRoute] string dbName, [FromBody] Table table)
        {
            _dbmsService.AddTable(dbName, table);

            return Ok(string.Format(ResponseMessages.TableCreated, dbName, table.Name));
        }

        //[HttpPost()]
        //[Route("{dbname}/insert/in/{tableName}")]
        //public IActionResult Insert([FromRoute] string dbName, [FromRoute] Table tableName)
        //{

        //    return Ok(string.Format(ResponseMessages.TableCreated, dbName, table.Name));
        //}
    }
}
