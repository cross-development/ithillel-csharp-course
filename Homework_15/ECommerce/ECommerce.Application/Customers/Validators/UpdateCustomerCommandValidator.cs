using FluentValidation;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Application.Customers.Validators;

/// <summary>
/// Validator for <see cref="UpdateCustomerCommand"/>.
/// </summary>
public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    /// <summary>
    /// Creates validator rules.
    /// </summary>
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(320);
        RuleFor(x => x.Phone).MaximumLength(30);
    }
}