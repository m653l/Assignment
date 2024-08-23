using FluentValidation;

namespace Application.Products.Create;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.ProductName)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingProductName)
            .MaximumLength(200).WithErrorCode(ProductErrorCodes.CreateProduct.ToLongProductName);

        RuleFor(c => c.ProductCode)
            .NotEmpty().WithErrorCode(ProductErrorCodes.CreateProduct.MissingProductCode)
            .MaximumLength(5).WithErrorCode(ProductErrorCodes.CreateProduct.ToLongProductCode);
    }
}
