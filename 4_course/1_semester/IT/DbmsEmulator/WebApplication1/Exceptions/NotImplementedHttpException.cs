using System.Net;

namespace DbmsEmulator.Exceptions
{
    public class NotImplementedHttpException : HttpException
    {
        private const HttpStatusCode _statusCode = HttpStatusCode.NotImplemented;

        public NotImplementedHttpException(string message) : base(message, _statusCode)
        {
        }
    }
}
