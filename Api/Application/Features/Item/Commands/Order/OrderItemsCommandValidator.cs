using FluentValidation;

namespace Api.Application.Features.Item.Commands.Order;

public class OrderItemsCommandValidator : AbstractValidator<OrderItemsCommand>
{
    public OrderItemsCommandValidator()
    {
        RuleForEach(o => o.ItemsToOrder)
            .Must(GreaterThenZero).WithMessage("Amount must be greater than 0");
    }

    private bool GreaterThenZero(OrderItem item)
    {
        return item.Quantity > 0;
    }
}