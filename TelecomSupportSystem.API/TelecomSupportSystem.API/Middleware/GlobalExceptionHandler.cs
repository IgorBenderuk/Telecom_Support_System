using Microsoft.AspNetCore.Diagnostics;

namespace TelecomSupportSystem.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsJsonAsync(new { Error = "Something went wrong" });
            return true;
        }
    }
}
