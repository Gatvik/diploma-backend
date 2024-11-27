using MediatR;

namespace Api.Application.Features.Item.Commands.Order;

public class OrderItemsCommand : IRequest<Unit>
{
    public OrderItem[] ItemsToOrder { get; set; }
}