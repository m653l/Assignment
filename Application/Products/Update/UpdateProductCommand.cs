using Application.Abstractions.Messaging;

namespace Application.Products.Update;

public sealed record UpdateProductCommand(Guid ProductId, Guid CategoryId, string ProductName, string ProductCode, decimal Price)
    : ICommand<Guid>;
