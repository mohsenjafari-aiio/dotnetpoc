﻿using aiio.Framework.Abstractions;
using MediatR;

namespace aiio.Framework.CQRS
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ISender _sender;

        public CommandProcessor(ISender sender)
        {
            _sender = sender;
        }

        public Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            return _sender.Send(command, cancellationToken);
        }
    }
}
