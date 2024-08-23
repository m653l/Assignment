using Domain.Products;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
