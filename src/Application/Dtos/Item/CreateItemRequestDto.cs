namespace OrderApi.src.Application.Dtos.Item;

public class CreateItemRequestDto
{
    public string Product { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
