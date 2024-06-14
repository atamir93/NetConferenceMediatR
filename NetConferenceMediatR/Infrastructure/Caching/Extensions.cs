using Microsoft.Extensions.DependencyInjection;

namespace NetConferenceMediatR.Infrastructure;

public static class AddCachingServiceExtensions
{
    public static void AddCachingService(this IServiceCollection services)
    {
        services.AddSingleton<ICachingService, CachingService>();
    }
}