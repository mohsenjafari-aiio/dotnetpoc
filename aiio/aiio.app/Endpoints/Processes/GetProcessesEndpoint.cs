﻿using aiio.Contract.Processes.Queries;
using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;
using FluentResults;

namespace aiio.app.Endpoints.Processes
{
    public static class GetProcessesEndpoint
    {
        internal static IEndpointRouteBuilder MapGetProcessesEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/GetAllProcesses", GetProcesses)
                .WithTags("Process")
                .Produces<GetProcessesResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)                
                .WithName("GetProcesses")
                .WithDisplayName("GetProcesses");

            return endpoints;
        }

        private static async Task<IResult> GetProcesses(            
            IQueryProcessor queryProcessor,
            CancellationToken cancellationToken)
        {
            var query = new GetProcessesQuery();
            var result = await queryProcessor.SendAsync(query, cancellationToken);

            return Results.Ok(result.Value);
        }
    }
}
