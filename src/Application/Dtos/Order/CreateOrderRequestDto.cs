using OrderApi.src.Application.Dtos.Item;
using OrderApi.src.Domain.Enums;

namespace OrderApi.src.Application.Dtos.Order;

public class CreateOrderRequestDto
{
    public OrderType Type { get; set; }

    public List<CreateItemRequestDto> Items { get; set; } = new();
}