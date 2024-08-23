using SharedKernel;

namespace Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
        "Category.NotFound",
        $"The category with Id = '{id}' was not found");
}
