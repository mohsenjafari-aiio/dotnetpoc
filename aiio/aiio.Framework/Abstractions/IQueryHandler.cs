using MediatR;

namespace aiio.Framework.Abstractions;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
where TQuery : IQuery<TResult>;