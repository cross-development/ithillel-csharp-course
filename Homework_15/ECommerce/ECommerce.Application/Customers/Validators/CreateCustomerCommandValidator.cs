using FluentValidation;
using ECommerce.Application.Customers.Commands;

namespace ECommerce.Application.Customers.Validators;

/// <summary>
/// Validator for <see cref="CreateCustomerCommand"/>.
/// </summary>
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Creates validator rules.
    /// </summary>
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(320);
        RuleFor(x => x.Phone).MaximumLength(30);
    }
}