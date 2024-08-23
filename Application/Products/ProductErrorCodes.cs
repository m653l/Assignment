namespace Application.Products;

public static class ProductErrorCodes
{
    public static class CreateOrUpdateProduct
    {
        public const string MissingProductName = nameof(MissingProductName);
        public const string MissingProductCode = nameof(MissingProductCode);
        public const string ToLongProductCode = nameof(ToLongProductCode);
        public const string ToLongProductName = nameof(ToLongProductName);
        public const string ProductIdMissing = nameof(ProductIdMissing);
    }
}
