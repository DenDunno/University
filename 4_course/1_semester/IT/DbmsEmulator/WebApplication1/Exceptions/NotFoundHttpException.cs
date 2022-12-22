using System.Net;

namespace DbmsEmulator.Exceptions
{
    public class NotFoundHttpException : HttpException
    {
        private const HttpStatusCode _statusCode = HttpStatusCode.NotFound;

        public NotFoundHttpException(string message) : base(message, _statusCode)
        {
        }
    }
}
