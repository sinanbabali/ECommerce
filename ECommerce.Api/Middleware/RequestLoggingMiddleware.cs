using Microsoft.AspNetCore.Http;
using Serilog;
using System.Diagnostics;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();

        Log.Information("HTTP {Method} {Url} responded {StatusCode} in {Elapsed:0.0000} ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.Elapsed.TotalMilliseconds);
    }
}
