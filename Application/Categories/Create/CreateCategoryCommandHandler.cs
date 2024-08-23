using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using SharedKernel;

namespace Application.Categories.Create;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateCategoryCommand commnd, 
        CancellationToken cancellationToken)
    {
        Category category = Category.Create(commnd.FullName, commnd.ShortName);

        categoryRepository.Insert(category);

        await unitOfWork.SaveChangesAsync();

        return category.Id;
    }
}
