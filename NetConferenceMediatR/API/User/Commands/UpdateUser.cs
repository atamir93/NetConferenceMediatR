using MediatR;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User;

internal record UpdateUser(long UserId, UpdateUserPayload UpdateUserPayload) : IRequest<UpdateUserResponse>;

internal record UpdateUserPayload(string FirstName, string LastName, string Email);
internal record UpdateUserResponse(Infrastructure.User User);

internal class UpdateUserHandler(IUserService userService) : IRequestHandler<UpdateUser, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var user = await userService.UpdateUserByIdAsync(request.UserId,
                                                        request.UpdateUserPayload.FirstName,
                                                        request.UpdateUserPayload.LastName,
                                                        request.UpdateUserPayload.Email);

        return new UpdateUserResponse(user);
    }
}