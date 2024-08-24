namespace Application.Products.GetAll;

public sealed record ProductResponse
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; init; }
    public string ProductName { get; init; }
    public string ProductCode { get; init; }
    public decimal Price { get; init; }
}
