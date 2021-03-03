using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace QLNS.Helpers.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }

        private static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var response = new { message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = Constants.JSONRESPONSE;
            context.Response.StatusCode = 400;

            return context.Response.WriteAsync(payload);
        }
    }
}
