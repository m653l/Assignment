namespace Application.Products;

public sealed class ProductNotFoundException : Exception
{
    public ProductNotFoundException(Guid productId)
        : base($"The product with the identifier {productId} was not found")
    {
        ProductId = productId;
    }

    public Guid ProductId { get; }
}
