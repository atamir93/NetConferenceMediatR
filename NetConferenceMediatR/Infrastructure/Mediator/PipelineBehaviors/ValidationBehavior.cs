using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NetConferenceMediatR.Infrastructure;

public static class AddValidationBehaviorExtension
{
    public static void AddValidationBehavior(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}

public interface IRequestValidator<in TRequest> where TRequest : notnull
{
    Task ValidateAsync(TRequest request);
}


public class ValidationBehavior<TRequest, TResponse>(IServiceProvider serviceProvider) :
    IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Check if a validator is available
        var validatorForRequest = serviceProvider.GetService<IRequestValidator<TRequest>>();

        if (validatorForRequest is not null)
        {
            await validatorForRequest.ValidateAsync(request).ConfigureAwait(false);
        }

        return await next().ConfigureAwait(false);
    }
}