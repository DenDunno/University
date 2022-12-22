using DbmsEmulator.Constants;
using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Models.RequestModels;
using DbmsEmulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbmsEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly DbmsService _dbmsService;
        private readonly AddressService _addressService;

        public TableController(DbmsService dbmsService, AddressService addressService)
        {
            _dbmsService = dbmsService;
            _addressService = addressService;
        }

        [HttpPost()]
        [Route("create")]
        public IActionResult CreateTable([FromBody] BaseAddress address)
        {
            DatabaseModel db = _addressService.GetDatabase(address.DatabaseName);

            DatabaseService dbService = new(db);
            dbService.CreateTable(address.TableName);

            return Ok(string.Format(ResponseMessages.TableCreated,
                address.TableName, address.DatabaseName));
        }

        [HttpDelete()]
        [Route("drop")]
        public IActionResult DropTable([FromBody] BaseAddress address)
        {
            DatabaseModel db = _dbmsService.TryGetDatabase(address.DatabaseName);

            DatabaseService dbService = new(db);
            dbService.DropTable(address.TableName);

            return Ok(string.Format(ResponseMessages.TableDropped,
                address.TableName, address.DatabaseName));
        }

        [HttpPost()]
        [Route("add/column")]
        public IActionResult AddColumn([FromBody] ColumnInTable column)
        {
            TableModel table = _addressService.GetTable(column.BaseAddress);

            TableService tableService = new(table);
            tableService.AddColumn(column.ColumnType);

            return Ok(string.Format(ResponseMessages.ColumnAdded,
                column.BaseAddress.DatabaseName, column.BaseAddress.TableName));
        }

        [HttpDelete()]
        [Route("delete/column/{index}")]
        public IActionResult DeleteColumn([FromRoute] int index, [FromBody] BaseAddress address)
        {
            TableModel table = _addressService.GetTable(address);

            TableService tableService = new(table);
            tableService.DeleteColumn(index);

            return Ok(string.Format(ResponseMessages.ColumnDeleted,
                address.DatabaseName, address.TableName));
        }

        [HttpPost()]
        [Route("insert/row")]
        public IActionResult InsertRow([FromBody] RowInTable row)
        {
            TableModel table = _addressService.GetTable(row.BaseAddress);

            TableService tableService = new(table);
            tableService.InsertRow(row.Values);

            return Ok(string.Format(ResponseMessages.RowInserted,
                row.BaseAddress.DatabaseName, row.BaseAddress.TableName));
        }

        [HttpDelete()]
        [Route("delete/row/{index}")]
        public IActionResult DeleteRow([FromRoute] int index, [FromBody] BaseAddress address)
        {
            TableModel table = _addressService.GetTable(address);

            TableService tableService = new(table);
            tableService.DeleteRow(index);

            return Ok(string.Format(ResponseMessages.RowDeleted,
                address.DatabaseName, address.TableName));
        }

        [HttpPatch()]
        [Route("set/value")]
        public IActionResult SetValue([FromBody] CellInTable cell)
        {
            TableModel table = _addressService.GetTable(cell.BaseAddress);

            TableService tableService = new(table);
            tableService.SetValue(cell.Value, cell);

            return Ok(string.Format(ResponseMessages.ValueSet, cell.Value.ToString(),
                cell.BaseAddress.DatabaseName, cell.BaseAddress.TableName,
                cell.RowNumber, cell.ColumnNumber));
        }
    }
}
