﻿using aiio.Framework.Abstractions;
using MediatR;

namespace aiio.Framework.CQRS
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly ISender _sender;

        public QueryProcessor(ISender sender)
        {
            _sender = sender;
        }

        public Task<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            return _sender.Send(query, cancellationToken);
        }
    }
}
