using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;

namespace aiio.Contract.Processes.Queries;

public record GetProcessQuery(int processId) : IQuery<FluentResults.Result<GetProcessResponse>>;