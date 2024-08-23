using Application.Categories.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Categories;

public class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories", async (
            UpdateCategoryRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateCategoryCommand(
                request.CategoryId,
                request.FullName,
                request.ShortName);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
