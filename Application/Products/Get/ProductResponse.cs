namespace Application.Products.Get;

public sealed class ProductResponse
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; init; }
    public string ProductName { get; init; }
    public string ProductCode { get; init; }
    public decimal Price { get; init; }
}
