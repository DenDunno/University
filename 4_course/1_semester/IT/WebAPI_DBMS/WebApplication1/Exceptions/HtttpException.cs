using System.Net;
using System.Web.Http;

namespace DbmsEmulator.Exceptions
{
    public class HttpException : HttpResponseException
    {
        public new readonly string Message;

        public HttpException(string message, HttpStatusCode statusCode)
            : base(statusCode)
        {
            Message = message;
        }
    }
}
