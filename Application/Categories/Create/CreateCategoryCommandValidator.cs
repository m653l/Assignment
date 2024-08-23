using FluentValidation;

namespace Application.Categories.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.MissingFullName)
            .MaximumLength(200).WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.ToLongFullName);

        RuleFor(c => c.ShortName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.MissingShortName)
            .MaximumLength(20).WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.ToLongShortName);
    }
}
