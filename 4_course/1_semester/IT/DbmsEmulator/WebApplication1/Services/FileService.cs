using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Exceptions;
using DbmsEmulator.Models.DbModels;
using Newtonsoft.Json;

namespace DbmsEmulator.Services
{
    public static class FileService
    {
        public static void Write(DatabaseModel database)
        {
            string databaseInJson = JsonConvert.SerializeObject(database);

            File.WriteAllText(database.Name, databaseInJson);
        }

        public static DatabaseModel Read(string name)
        {
            try
            {
                string databaseInJson = File.ReadAllText(name);

                return JsonConvert.DeserializeObject<DatabaseModel>(databaseInJson)!;
            }
            catch
            {
                throw new NotFoundHttpException(ErrorMessages.DatabaseNotFound);
            }
        }
    }
}
