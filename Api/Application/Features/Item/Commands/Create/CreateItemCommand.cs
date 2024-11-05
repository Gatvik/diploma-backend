using MediatR;

namespace Api.Application.Features.Item.Commands.Create;

public class CreateItemCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }
}