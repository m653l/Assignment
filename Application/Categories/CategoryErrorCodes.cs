namespace Application.Categories;

public static class CategoryErrorCodes
{
    public static class CreateCategory
    {
        public const string MissingFullName = nameof(MissingFullName);
        public const string MissingShortName = nameof(MissingShortName);
        public const string ToLongFullName = nameof(ToLongFullName);
        public const string ToLongShortName = nameof(ToLongShortName);
    }
}
