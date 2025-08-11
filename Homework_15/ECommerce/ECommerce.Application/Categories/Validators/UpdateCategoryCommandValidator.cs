using FluentValidation;
using ECommerce.Application.Categories.Commands;

namespace ECommerce.Application.Categories.Validators;

/// <summary>
/// Validator for <see cref="UpdateCategoryCommand"/>.
/// </summary>
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    /// <summary>
    /// Creates validator rules.
    /// </summary>
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(1000);
    }
}