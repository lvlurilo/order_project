using OrderApi.src.Domain.Entities.Base;

namespace OrderApi.src.Domain.Entities;

public class Item : EntityBase
{
    public Guid OrderPublicId { get; set; }

    public string Product { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice => Quantity * Price;

    public Item(string product, int quantity, decimal price, Guid orderPublicId)
    {
        OrderPublicId = orderPublicId;
        Product = product;
        Quantity = quantity;
        Price = price; 
        SetUpdatedAt(); 
    }
}