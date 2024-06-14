using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetConferenceMediatR.API.User.Extensions;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR
{
    [TestClass]
    public abstract class MediatorTestBase
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext _)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<MediatorTestBase>();
            });

            serviceCollection.AddMediatorPipelineBehaviors();
            serviceCollection.AddUsersApi();

            var services = serviceCollection.BuildServiceProvider();
            Mediator = services.GetService<IMediator>();
        }

        protected static IMediator Mediator { get; private set; } = null!;
    }
}
