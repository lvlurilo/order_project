using OrderApi.src.Application.Dtos.Item;

namespace OrderApi.src.Application.Dtos.Order;

public class GetOrderResponseDto
{
    public Guid PublicId { get; set; }
    public List<GetItemResponseDto> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
}