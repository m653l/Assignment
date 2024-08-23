using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using SharedKernel;

namespace Application.Products.Create;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        Product product = Product.Create(command.CategoryId, command.ProductName, command.ProductCode, command.Price);

        productRepository.Insert(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
