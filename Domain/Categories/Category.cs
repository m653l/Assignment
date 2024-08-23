using SharedKernel;

namespace Domain.Categories;

public sealed class Category : Entity
{
    public string FullName { get; private set; }
    public string ShortName { get; private set; }

    public static Category Create(string fullName, string shortName)
    {
        Category category = new Category()
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            ShortName = shortName
        };

        return category;
    }
}
