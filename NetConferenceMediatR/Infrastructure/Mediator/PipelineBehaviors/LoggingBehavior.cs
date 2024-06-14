using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NetConferenceMediatR.Infrastructure;

public static class AddLoggingBehaviorExtension
{
    public static void AddLoggingBehavior(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Starting '{typeof(TRequest).Name}' request ");

        var result = await next();

        Console.WriteLine($"Request '{typeof(TRequest).Name}' is completed.");

        return result;
    }
}