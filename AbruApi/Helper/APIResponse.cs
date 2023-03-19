using System.Net;

namespace AbruApi.Helper
{
    public class APIResponse
    {
        public APIResponse()
        {
            messages = new List<string>();
        }
        public HttpStatusCode statusCode { get; set; }
        public bool isSuccess { get; set; }
        public List<string> messages { get; set; }
        public object? result { get; set; }
    }
}
