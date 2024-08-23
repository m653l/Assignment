using FluentValidation;

namespace Application.Products.Create;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.ProductName)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.MissingProductName)
            .MaximumLength(200).WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.ToLongProductName);

        RuleFor(c => c.ProductCode)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.MissingProductCode)
            .MaximumLength(5).WithErrorCode(ProductErrorCodes.CreateOrUpdateProduct.ToLongProductCode);
    }
}
