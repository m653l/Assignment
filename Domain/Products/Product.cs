using SharedKernel;

namespace Domain.Products;

public sealed class Product : Entity
{
    public Guid CategoryId { get; private set; }
    public string ProductName { get; private set; }
    public string ProductCode { get; private set; }
    public decimal Price { get; private set; }

    public static Product Create(Guid categoryId, string productName, string productCode, decimal price)
    {
        Product product = new Product()
        {
            Id = Guid.NewGuid(),
            ProductName = productName,
            ProductCode = productCode,
            Price = price
        };

        return product;
    }
}
