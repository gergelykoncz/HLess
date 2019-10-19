using HLess.Models.Exceptions;
using HLess.Models.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HLess.API.ErrorHandling
{
    /// <summary>
    /// Middleware catching unhandled exceptions and standardizing
    /// the error response.
    /// </summary>
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
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var customException = exception as ApiException;
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "UNEXPECTED_ERROR";

            if (null != customException)
            {
                message = customException.Message;
                statusCode = customException.ErrorCode;
            }

            response.Clear();
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(new ApiError
            {
                StatusCode = (int)statusCode,
                Message = message
            }));
        }
    }
}
