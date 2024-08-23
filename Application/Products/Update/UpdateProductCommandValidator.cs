using FluentValidation;

namespace Application.Products.Update;

internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.ProductId)
            .NotEmpty()
            .WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.ProductIdMissing);

        RuleFor(c => c.ProductName)
            .MaximumLength(200).WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.ToLongProductName);

        RuleFor(c => c.ProductCode)
            .MaximumLength(5).WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.ToLongProductCode);
    }
}
