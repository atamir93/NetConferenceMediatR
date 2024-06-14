using Microsoft.Extensions.DependencyInjection;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User
{
    internal static class AddUserValidatorExtension
    {
        public static void AddAddUserValidator(this IServiceCollection services)
        {
            services.AddSingleton<IRequestValidator<AddUser>, AddUserValidator>();
        }
    }

    internal class AddUserValidator : IRequestValidator<AddUser>
    {
        public Task ValidateAsync(AddUser request)
        {
            if (!request.AddUserPayload.Email.Contains("@"))
            {
                throw new InvalidRequestException("Invalid email address");
            }

            return Task.CompletedTask;
        }
    }
}
