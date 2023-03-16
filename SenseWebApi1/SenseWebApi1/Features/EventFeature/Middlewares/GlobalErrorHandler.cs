using System.Collections.Generic;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using SenseWebApi1.domain.Exceptions;

namespace SenseWebApi1.Features.MyFeature.Middlewares
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandler> _logger;

        public GlobalErrorHandler(RequestDelegate next, ILogger<GlobalErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(ArgumentException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch(ExceptionsAdapter ex)
            {
                await HandleExceptionAsync(httpContext, ex.Exceptions);
                
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }
        private  async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            context.Response.StatusCode = 400;
            string result = exception.Message;
            _logger.LogError(exception.Message);
            await response.WriteAsync(result);
        }
        private async Task HandleExceptionAsync(HttpContext context, IEnumerable<string> errors)
        {
            context.Response.ContentType = "application/json";
            string response = "";
            foreach (var error in errors)
            {
                 response+= error+"\n";
            }
   
            context.Response.StatusCode = 400;
            
            _logger.LogError(response);
            await context.Response.WriteAsync(response);
        }
    }
}
