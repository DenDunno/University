using DbmsEmulator.Exceptions;
using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Models.DbModels;

namespace DbmsEmulator.Services
{
    public class DbmsService
    {
        private readonly List<Database> _databases;

        public DbmsService(List<Database> databases) =>
            _databases = databases;

        public void CreateDatabase(Database database)
        {
            if (_databases.Any(db => db.Name == database.Name))
            {
                throw new NotImplementedHttpException(ErrorMessages.DbWithSuchNameAlreadyExists);
            }

            _databases.Add(database);
        }

        public void AddTable(string dbName, Table table)
        {
            try
            {
                Database database = _databases.First(db => db.Name == dbName);

                database.Tables.Add(table);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundHttpException(ErrorMessages.DatabaseNotFound);
            }
        }
    }
}
