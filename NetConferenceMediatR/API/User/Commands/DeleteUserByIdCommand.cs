using MediatR;
using NetConferenceMediatR.Infrastructure;

namespace NetConferenceMediatR.API.User;

internal record DeleteUserById(long Id) : IRequest<DeleteUserByIdResponse>;
internal record DeleteUserByIdResponse(bool Success);

internal class DeleteUserByIdHandler(IUserService userService) : IRequestHandler<DeleteUserById, DeleteUserByIdResponse>
{
    public async Task<DeleteUserByIdResponse> Handle(DeleteUserById request, CancellationToken cancellationToken)
    {
        var isUserDeleted = await userService.DeleteUserByIdAsync(request.Id);

        return new DeleteUserByIdResponse(isUserDeleted);
    }
}