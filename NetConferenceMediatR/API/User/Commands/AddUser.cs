using MediatR;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User;

internal record AddUser(AddUserPayload AddUserPayload) : IRequest<AddUserResponse>;

internal record AddUserPayload(string FirstName, string LastName, string Email, DateTime Birthdate);
internal record AddUserResponse(long Id);

internal class AddUserHandler(IUserService userService) : IRequestHandler<AddUser, AddUserResponse>
{
    public async Task<AddUserResponse> Handle(AddUser request, CancellationToken cancellationToken)
    {
        var userId = await userService.AddUserAsync(request.AddUserPayload.FirstName,
                                                request.AddUserPayload.LastName,
                                                request.AddUserPayload.Email,
                                                request.AddUserPayload.Birthdate);

        return new AddUserResponse(userId);
    }
}