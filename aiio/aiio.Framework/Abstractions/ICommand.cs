using MediatR;

namespace aiio.Framework.Abstractions;

public interface ICommand<out TResult> : IRequest<TResult>; 