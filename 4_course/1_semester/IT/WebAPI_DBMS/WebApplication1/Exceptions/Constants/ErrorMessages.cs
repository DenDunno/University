using FluentValidation;

namespace DbmsEmulator.Exceptions.Constants
{
    public static class ErrorMessages
    {
        public const string ValidationException = "Validation exception";
        public const string DbWithSuchNameAlreadyExists = "Database with the same name already exists";
        public const string DatabaseNotFound = "Database with such a name doesn't exist";
    }
}
