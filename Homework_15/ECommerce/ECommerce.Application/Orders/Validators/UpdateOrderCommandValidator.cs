using ECommerce.Application.Orders.Commands;
using FluentValidation;

namespace ECommerce.Application.Orders.Validators;

/// <summary>
/// Validator for update order command.
/// </summary>
public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    /// <summary>
    /// Constructs validator rules.
    /// </summary>
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Items).NotNull().NotEmpty();
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId).NotEmpty();
            item.RuleFor(i => i.Quantity).GreaterThan(0);
            item.RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(0);
        });
    }
}