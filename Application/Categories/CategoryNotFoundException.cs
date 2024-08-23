namespace Application.Categories;

public sealed class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(Guid productId)
        : base($"The category with the identifier {productId} was not found")
    {
        ProductId = productId;
    }

    public Guid ProductId { get; }
}
