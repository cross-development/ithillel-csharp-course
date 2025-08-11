using FluentValidation;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Application.Products.Validators;

/// <summary>
/// Validator for <see cref="UpdateProductCommand"/>.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Creates validator rules.
    /// </summary>
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(2000);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
}
