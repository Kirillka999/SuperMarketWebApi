using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.Core.Exceptions;

namespace SuperMarketWebApi.ExceptionHandlers;

public class OrderAddExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not OrderAddException)
        {
            return false;
        }
        
        var details = new ProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = string.IsNullOrWhiteSpace(exception.Message) ?  "Some mysterious error" : exception.Message
        };
        
        httpContext.Response.StatusCode = details.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

        return true;
    }
}