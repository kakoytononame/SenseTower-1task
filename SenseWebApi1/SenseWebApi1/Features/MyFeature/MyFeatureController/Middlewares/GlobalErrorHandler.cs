using System.Collections.Generic;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Middlewares
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandler> _logger;

        public GlobalErrorHandler(RequestDelegate next,ILogger<GlobalErrorHandler> logger)
        {
            _next=next;
            _logger=logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string result="Ошибка на сервере"+code.ToString();
            
            _logger.LogError(exception.Message);
            
            await response.WriteAsync(result);
        }
    }
}
