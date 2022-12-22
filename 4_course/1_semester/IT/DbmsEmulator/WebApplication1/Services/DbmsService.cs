using DbmsEmulator.Exceptions;
using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Models.DbModels;

namespace DbmsEmulator.Services
{
    public class DbmsService
    {
        private readonly List<DatabaseModel> _databases = new();

        public void CreateDatabase(string name)
        {
            if (_databases.Any(db => db.Name == name))
            {
                throw new NotImplementedHttpException(ErrorMessages.DbWithSamehNameAlreadyExists);
            }

            DatabaseModel db = new(name);
            db.Validate();

            _databases.Add(db);
        }

        public void DropDatabase(string name)
        {
            DatabaseModel db = TryGetDatabase(name);

            _databases.Remove(db);
        }

        public DatabaseModel TryGetDatabase(string name)
        {
            DatabaseModel? db = _databases.FirstOrDefault(db => db.Name == name);

            if (db is null)
            {
                throw new NotFoundHttpException(ErrorMessages.DatabaseNotFound);
            }

            return db;
        }
    }
}
