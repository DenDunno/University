using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Exceptions;
using DbmsEmulator.Models.DbModels;

namespace DbmsEmulator.Services
{
    public class DatabaseService
    {
        private readonly DatabaseModel _database;

        public DatabaseService(DatabaseModel database)
        {
            _database = database;
        }

        public void CreateTable(string name)
        {
            if (_database.Tables.Any(table => table.Name == name))
            {
                throw new NotImplementedHttpException(ErrorMessages.TableWithSameNameAlreadyExists);
            }

            TableModel table = new(name);

            _database.Tables.Add(table);
        }

        public void DropTable(string name)
        {
            TableModel table = TryGetTable(name);

            _database.Tables.Remove(table);
        }

        public TableModel TryGetTable(string name)
        {
            TableModel? table = _database.Tables.FirstOrDefault(db => db.Name == name);

            if (table is null)
            {
                throw new NotFoundHttpException(ErrorMessages.TableNotFound);
            }

            return table;
        }
    }
}
