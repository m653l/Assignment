using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using SharedKernel;

namespace Application.Categories.Update;

internal sealed class UpdateCategoryCommndHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category == null)
            return Result.Failure<Guid>(CategoryErrors.NotFound(command.CategoryId));

        category.Update(command.FullName, command.ShortName);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
