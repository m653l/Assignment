using Application.Abstractions.Messaging;

namespace Application.Products.Create;

public sealed record CreateProductCommand(Guid CategoryId, string ProductName, string ProductCode, decimal Price)
    : ICommand<Guid>;
