using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace AbruApi.Helper
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            var response = new APIResponse
            {
                statusCode = HttpStatusCode.InternalServerError,
                isSuccess = false,
                messages = new List<string> { $"{ex.Message}" },
                result = null
            };

            if (ex is APIException apiException)
            {
                response.statusCode = apiException.StatusCode;
                response.messages.Clear();

                response.messages.Add(apiException.Messages);
            }

            var result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }
    }

}
