using SharedKernel;

namespace Domain.Products;

public static class ProductErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
        "Products.NotFound",
        $"The user with the Id = '{id}' was not found");
}
