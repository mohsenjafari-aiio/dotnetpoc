using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;

namespace aiio.Contract.Processes.Commands;

public record UpdateProcessCommand : ICommand<FluentResults.Result<UpdateProcessResponse>>;