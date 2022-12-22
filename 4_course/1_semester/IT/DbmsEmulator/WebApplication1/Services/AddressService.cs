using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Models.RequestModels;

namespace DbmsEmulator.Services
{
    public class AddressService
    {
        private readonly DbmsService _dbmsService;

        public AddressService(DbmsService dbmsService)
        {
            _dbmsService = dbmsService;
        }

        public DatabaseModel GetDatabase(string name)
        {
            return _dbmsService.TryGetDatabase(name);
        }

        public TableModel GetTable(BaseAddress address)
        {
            DatabaseModel db = _dbmsService.TryGetDatabase(address.DatabaseName);

            DatabaseService dbService = new(db);

            TableModel table = dbService.TryGetTable(address.TableName);

            return table;
        }
    }
}
