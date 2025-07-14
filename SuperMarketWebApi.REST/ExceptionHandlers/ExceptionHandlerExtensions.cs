namespace SuperMarketWebApi.ExceptionHandlers;

public static class ExceptionHandlerExtensions
{
    public static IServiceCollection AddGlobalExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<GetCartExceptionHandler>();
        services.AddExceptionHandler<OrderAddExceptionHandler>();
        services.AddExceptionHandler<OrderPlaceExceptionHandler>();
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        services.AddProblemDetails();
        
        return services;
    }
}