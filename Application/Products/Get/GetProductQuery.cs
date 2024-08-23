using Application.Abstractions.Messaging;

namespace Application.Products.Get;

public sealed record GetProductQuery(Guid productId) : IQuery<ProductResponse>;
