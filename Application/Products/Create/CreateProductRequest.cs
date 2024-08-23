namespace Application.Products.Create;

public sealed record CreateProductRequest(Guid CategoryId, string ProductName, string ProductCode, decimal Price);