namespace OrderApi.src.Application.Dtos.Item;

public class GetItemResponseDto
{
    public Guid PublicId { get; set; }
    public string Product { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}
