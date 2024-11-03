using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
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
            Log.Error(ex, "An unhandled exception occurred!"); 
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var result = System.Text.Json.JsonSerializer.Serialize(new
        {
            status = context.Response.StatusCode,
            message = "An unexpected error occurred.",
            detailed = exception.Message 
        });

        return context.Response.WriteAsync(result);
    }
}
