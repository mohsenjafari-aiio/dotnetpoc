using MediatR;

namespace aiio.Framework.Abstractions;

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
where TCommand : ICommand<TResult>;