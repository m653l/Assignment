using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Products;
using SharedKernel;

namespace Application.Categories.Delete;

internal sealed class DeleteCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProductsWithCategotyIdAsync(command.CategoryId, cancellationToken);

        foreach (var product in products)
        {
            product.SoftDelete();
        }

        var category = await categoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category is null)
            return Result.Failure<Guid>(ProductErrors.NotFound(command.CategoryId));

        category.SoftDelete();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
