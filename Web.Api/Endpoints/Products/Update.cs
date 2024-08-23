using Application.Products.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("products", async (
            UpdateProductRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateProductCommand(
                request.ProductId,
                request.CategoryId,
                request.ProductName,
                request.ProductCode,
                request.Price);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}
