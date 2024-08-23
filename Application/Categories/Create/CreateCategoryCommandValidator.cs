using FluentValidation;

namespace Application.Categories.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateCategory.MissingFullName)
            .MaximumLength(200).WithErrorCode(CategoryErrorCodes.CreateCategory.ToLongFullName);

        RuleFor(c => c.ShortName)
            .NotEmpty().WithErrorCode(CategoryErrorCodes.CreateCategory.MissingShortName)
            .MaximumLength(20).WithErrorCode(CategoryErrorCodes.CreateCategory.ToLongShortName);
    }
}
