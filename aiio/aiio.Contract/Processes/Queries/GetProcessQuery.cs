using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;

namespace aiio.Contract.Processes.Queries;

public record GetProcessQuery(Guid processId) : IQuery<FluentResults.Result<GetProcessResponse>>;