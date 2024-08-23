using SharedKernel;

namespace Domain.Products;

public static class ProductErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
        "Products.NotFound",
        $"The product with the Id = '{id}' was not found");

    public static Error CategoryNotFound(Guid categoryId) => Error.NotFound(
        "Products.CategoryNotFound",
        $"The category with the Id = '{categoryId}' was not found");
}
