﻿using aiio.Contract.Processes.Commands;
using aiio.Contract.Processes.Requests;
using aiio.Contract.Processes.Responces;
using aiio.Framework.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace aiio.app.Endpoints.Processes
{
    public static class UpdateProcessEndpoint
    {
        internal static IEndpointRouteBuilder MapUpdateProcessEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/UpdateProcess", UpdateProcess)
                .WithTags("Process")
                .Produces<UpdateProcessResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .WithName("UpdateProcess")
                .WithDisplayName("UpdateProcess");

            return endpoints;
        }

        private static async Task<IResult> UpdateProcess(
            [FromBody] UpdateProcessRequest request,
            ICommandProcessor commandProcessor,
            CancellationToken cancellationToken)
        {
            var command = new UpdateProcessCommand(request.Id, request.Title, request.Description);
            var result = await commandProcessor.SendAsync(command, cancellationToken);

            if (result.IsFailed)
                return Results.NotFound(result.Errors.FirstOrDefault());

            return Results.Ok(result.Value);

        }
    }
}
