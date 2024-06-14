using MediatR;

namespace NetConferenceMediatR.Infrastructure;

// Command with Response
public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}
