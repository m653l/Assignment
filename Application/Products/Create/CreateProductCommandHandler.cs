using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Products;
using SharedKernel;

namespace Application.Products.Create;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category == null)
            return Result.Failure<Guid>(ProductErrors.CategoryNotFound(command.CategoryId));

        Product product = Product.Create(command.CategoryId, command.ProductName, command.ProductCode, command.Price);

        productRepository.Insert(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
