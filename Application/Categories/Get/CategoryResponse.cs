namespace Application.Categories.Get;

public sealed record CategoryResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string ShortName { get; init; }
}
