using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;

namespace aiio.Contract.Processes.Queries;

public record GetProcessesQuery : IQuery<FluentResults.Result<GetProcessesResponse>>;