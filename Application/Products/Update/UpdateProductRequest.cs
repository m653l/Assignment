namespace Application.Products.Update;

public sealed record UpdateProductRequest(Guid ProductId, Guid CategoryId, string ProductName, string ProductCode, decimal Price);