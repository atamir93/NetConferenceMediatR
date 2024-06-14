using Microsoft.Extensions.DependencyInjection;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User.Extensions;

public static class AddUsersExtensions
{
    public static void AddUsersApi(this IServiceCollection services)
    {
        services.AddUserService();
        services.AddAddUserValidator();
    }
}