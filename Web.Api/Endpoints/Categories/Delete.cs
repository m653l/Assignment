using Application.Categories.Delete;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Categories;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("categories/delete", async (
            Guid categoryId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteCategoryCommand(categoryId);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
