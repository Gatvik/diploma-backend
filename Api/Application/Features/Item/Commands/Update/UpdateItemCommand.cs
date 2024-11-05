using MediatR;

namespace Api.Application.Features.Item.Commands.Update;

public class UpdateItemCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }
}