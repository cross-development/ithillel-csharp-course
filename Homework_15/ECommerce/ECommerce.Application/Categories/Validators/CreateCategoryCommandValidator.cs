using FluentValidation;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Application.Categories.Validators;

/// <summary>
/// Validator for <see cref="CreateCategoryCommand"/>.
/// </summary>
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    /// <summary>
    /// Creates validator rules.
    /// </summary>
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(1000);
    }
}