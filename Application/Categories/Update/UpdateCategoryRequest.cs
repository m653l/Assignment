namespace Application.Categories.Update;

public sealed record UpdateCategoryRequest(Guid CategoryId, string FullName, string ShortName);