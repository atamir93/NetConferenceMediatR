using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NetConferenceMediatR.Infrastructure
{
    public static class AddMediatorPipelineBehaviorsExtensions
    {
        public static void AddMediatorPipelineBehaviors(this IServiceCollection services)
        {
            services.AddLoggingBehavior();
            services.AddValidationBehavior();
            services.AddQueryCachingBehavior();
        }
    }
}
