using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using SharedKernel;

namespace Application.Products.Delete;

internal sealed class DeleteProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(command.ProductId, cancellationToken);

        if (product is null)
            return Result.Failure<Guid>(ProductErrors.NotFound(command.ProductId));

        product.SoftDelete();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
