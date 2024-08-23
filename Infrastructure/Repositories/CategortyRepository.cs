using Domain.Categories;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

internal sealed class CategortyRepository : Repository<Category>, ICategoryRepository
{
    public CategortyRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
