using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SuperMarketWebApi.ExceptionHandlers;

public class UnhandledExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred. Please try again later."
        };
        
        httpContext.Response.StatusCode = details.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

        return true;
    }
}