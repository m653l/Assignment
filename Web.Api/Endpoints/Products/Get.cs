using Application.Products.Get;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("products/{productId}", async (
            Guid productId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetProductQuery(productId);

            Result<ProductResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}
