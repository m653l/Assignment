using FluentValidation;

namespace Application.Categories.Update;

internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryId)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.CategoryIdMissing);

        RuleFor(c => c.FullName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.MissingFullName)
            .MaximumLength(200).WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.ToLongFullName);

        RuleFor(c => c.ShortName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.MissingShortName)
            .MaximumLength(20).WithErrorCode(CategoryErrorCodes.CreateOrUpdateCategory.ToLongShortName);
    }
}
