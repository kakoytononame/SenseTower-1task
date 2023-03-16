using System.Collections.Generic;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using SenseWebApi1.domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SC.Internship.Common.Exceptions;
using SC.Internship.Common.ScResult;
using System.Linq;

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
            catch(ScException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
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
            var jsonerror = JsonSerializer.Serialize(new ScResult() { Error = new ScError() { Message = result } });
            await response.WriteAsync(jsonerror);
            
        }
        private async Task HandleExceptionAsync(HttpContext context, Dictionary<string, List<string>> errors)
        {
            context.Response.ContentType = "application/json";
            string response = "";
            
            
            var dictionary=errors.ToDictionary(x=>x,y=>y);
            context.Response.StatusCode = 400;
            var jsonerror = JsonSerializer.Serialize(new ScResult() { Error = new ScError() { ModelState = errors } });
            _logger.LogError(response);
            await context.Response.WriteAsync(jsonerror);
        }
    }
}
