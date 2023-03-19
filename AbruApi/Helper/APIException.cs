using System.Net;

namespace AbruApi.Helper
{
    public class APIException : Exception
    {
        public APIException(HttpStatusCode statusCode, string Messages)
        {
            StatusCode = statusCode;
            this.Messages = Messages;
        }
        public HttpStatusCode StatusCode { get; }

        public readonly bool IsSuccess = false;
        public string Messages { get; }
    }
}
