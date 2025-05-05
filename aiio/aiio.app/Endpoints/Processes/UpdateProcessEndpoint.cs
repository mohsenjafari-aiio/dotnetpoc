using aiio.Contract.Processes.Commands;
using aiio.Contract.Processes.Requests;
using aiio.Contract.Student.Responces;
using aiio.Framework.Abstractions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace aiio.app.Endpoints.Processes
{
    public static class UpdateProcessEndpoint
    {
        internal static IEndpointRouteBuilder MapUpdateProcessEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/UpdateProcess", UpdateProcess)
                .WithTags("Process")
                .Produces<StudentResponse>(StatusCodes.Status201Created)
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
            if (!Guid.TryParse(request.Id, out var guid))
                return Results.BadRequest(Result.Fail("Invalid process ID"));

            var command = new UpdateProcessCommand(guid,request.Title, request.Description);
            var result = await commandProcessor.SendAsync(command, cancellationToken);

            if (result.IsFailed)
                return Results.NotFound(result.Errors.FirstOrDefault());

            return Results.Ok(result.Value);

        }
    }
}
