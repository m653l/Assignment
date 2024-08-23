using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Products;
using SharedKernel;

namespace Application.Products.Update;

internal sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByIdAsync(command.ProductId, cancellationToken);

        if (product == null)
            return Result.Failure<Guid>(ProductErrors.NotFound(command.ProductId));

        Category? category = await categoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category == null)
            return Result.Failure<Guid>(ProductErrors.CategoryNotFound(command.CategoryId));

        product.Update(command.CategoryId, command.ProductName, command.ProductCode, command.Price);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
