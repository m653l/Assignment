using Application.Abstractions.Messaging;

namespace Application.Categories.Create;

public sealed record CreateCategoryCommand(string FullName, string ShortName)
    : ICommand<Guid>;
