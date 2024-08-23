namespace Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<Product>> GetAllProductsWithCategotyIdAsync(Guid categotyId, CancellationToken cancellationToken = default);
    void Insert(Product product);
}
