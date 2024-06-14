using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NetConferenceMediatR.Infrastructure;

public static class AddQueryCachingBehaviorExtension
{
    public static void AddQueryCachingBehavior(this IServiceCollection services)
    {
        services.AddCachingService();

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(QueryCachingBehavior<,>));
    }
}

public class QueryCachingBehavior<TRequest, TResponse>(ICachingService cachingService) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery<TResponse>
    where TResponse : CachableObject
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //var result = await cachingService.GetOrCreateAsync(request.CacheKey,
        //    async () => await next(),
        //    request.CacheTime);

        var cachedResult = cachingService.Get<TResponse>(request.CacheKey);
        if (cachedResult is not null)
        {
            return cachedResult;
        }

        var result = await next();

        cachedResult = result with
        {
            CacheInfo = result.CacheInfo with
            {
                Key = request.CacheKey,
                CacheTime = request.CacheTime,
                ExpirationDateTimeUtc = DateTime.UtcNow.Add(request.CacheTime)
            }
        };

        return cachedResult;
    }
}