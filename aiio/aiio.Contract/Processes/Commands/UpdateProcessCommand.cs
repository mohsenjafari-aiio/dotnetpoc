using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;

namespace aiio.Contract.Processes.Commands;

public record UpdateProcessCommand(int Id, string Title, string? Description) : ICommand<FluentResults.Result<UpdateProcessResponse>>;