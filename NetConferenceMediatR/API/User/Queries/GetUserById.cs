using MediatR;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User;

internal record GetUserById(long Id) : IRequest<GetUserByIdResponse>;
internal record GetUserByIdResponse(Infrastructure.User User);

internal class GetUserByIdHandler(IUserService userService) : IRequestHandler<GetUserById, GetUserByIdResponse>
{
    public async Task<GetUserByIdResponse> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByIdAsync(request.Id);

        return new GetUserByIdResponse(user);
    }
}