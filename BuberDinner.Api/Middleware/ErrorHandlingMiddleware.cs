﻿using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuberDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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

                await HandleExectionAsync(context, ex);
            }
        }

        private Task HandleExectionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;      //500
            var result = JsonSerializer.Serialize(new { error = "An error occurred while processing your request" });
            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
