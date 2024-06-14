using MediatR;
using NetConferenceMediatR.Infrastructure;
using System.Collections.Immutable;

namespace NetConferenceMediatR.API.User;

internal record GetUsers() : IRequest<GetUsersResponse>;
internal record GetUsersResponse(IImmutableList<Infrastructure.User> Users);

internal class GetUsersHandler(IUserService userService) : IRequestHandler<GetUsers, GetUsersResponse>
{
    public async Task<GetUsersResponse> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var users = await userService.GetUsersAsync();

        return new GetUsersResponse(users);
    }
}