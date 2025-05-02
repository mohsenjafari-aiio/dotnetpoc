using aiio.Contract.Student.Commands;
using aiio.Contract.Student.Requests;
using aiio.Contract.Student.Responces;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;

namespace aiio.app.Endpoints
{
    public static class CreateStudentEndpoint
    {
        internal static IEndpointRouteBuilder MapCreateStudentEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/students", CreateStudent)
                .WithTags("Students")
                .Produces<StudentResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .WithName("CreateStudent")
                .WithDisplayName("CreateStudent");

            return endpoints;
        }

        private static async Task<IResult> CreateStudent(
            CreateStudentRequest request,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var command = new CreateStudentCommand(request.Name, request.Age);
            var result = await sender.Send(command, cancellationToken);

            return Results.Created($"/api/students/{result}", new { Id = result });
        }
    }
}