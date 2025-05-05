using aiio.Contract.Processes.Queries;
using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace aiio.app.Endpoints.Processes
{
    public static class GetProcessEndpoint
    {
        internal static IEndpointRouteBuilder MapGetProcessEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/GetProcessById", GetProcess)
                .WithTags("Process")
                .Produces<GetProcessResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .WithName("GetProcess")
                .WithDisplayName("GetProcess");

            return endpoints;
        }

        private static async Task<IResult> GetProcess(
            [FromQuery] string processId,
            IQueryProcessor queryProcessor,
            CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(processId, out var guid))
                return Results.BadRequest(Result.Fail("Invalid process ID"));

            var query = new GetProcessQuery(guid);
            var result = await queryProcessor.SendAsync(query, cancellationToken);

            if (result.IsFailed)
                return Results.NotFound(result.Errors.FirstOrDefault());

            return Results.Ok(result.Value);

        }
    }
}
