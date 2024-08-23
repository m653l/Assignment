using Domain.Products;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IList<Product>> GetAllProductsWithCategotyIdAsync(Guid categotyId, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<Product>()
            .Where(x => x.CategoryId == categotyId)
            .ToListAsync();
    }
}
