using OrderApi.src.Domain.Entities.Base;
using OrderApi.src.Domain.Enums;

namespace OrderApi.src.Domain.Entities;

public class Order : EntityBase
{
    public OrderType Type { get; set; }

    public decimal TotalPrice { get; set; }

    public Order(OrderType type)
    {

        Type = type;
        SetUpdatedAt();
    }
}