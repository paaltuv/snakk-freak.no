using Microsoft.AspNetCore.HttpLogging;

namespace Snakk.Web.Middleware;

public class StaticFileLoggingInterceptor : IHttpLoggingInterceptor
{
    public ValueTask OnRequestAsync(HttpLoggingInterceptorContext logContext)
    {
        var path = logContext.HttpContext.Request.Path.Value ?? "";
        var lastSegment = path.AsSpan(path.LastIndexOf('/') + 1);
        if (lastSegment.Contains('.'))
            logContext.LoggingFields = HttpLoggingFields.None;

        return ValueTask.CompletedTask;
    }

    public ValueTask OnResponseAsync(HttpLoggingInterceptorContext logContext) => ValueTask.CompletedTask;
}
