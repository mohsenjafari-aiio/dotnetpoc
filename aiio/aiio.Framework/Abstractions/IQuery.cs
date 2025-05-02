using MediatR;

namespace aiio.Framework.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>;