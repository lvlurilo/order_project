using OrderApi.src.Application.Dtos.Item;
using OrderApi.src.Application.Dtos.Order;
using OrderApi.src.Application.Interfaces;
using OrderApi.src.Domain.Entities;
using OrderApi.src.Domain.Enums;
using OrderApi.src.Domain.Interfaces;

namespace OrderApi.src.Application.Services;

public class OrderApplicationService : IOrderApplicationService
{
    private readonly IItemRepository _itemRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderApplicationService(IItemRepository itemRepository, IOrderRepository orderRepository)
    {
        _itemRepository = itemRepository;   
        _orderRepository = orderRepository;
    }

    public async Task<Guid> CreateAsync(CreateOrderRequestDto requestDto)
    {
        ValidateOrder(requestDto);

        var order = new Order(requestDto.Type);

        await _orderRepository.AddAsync(order);

        foreach(var item in requestDto.Items)
        {
            var newPrice = CalculatePrice(requestDto.Type, item.Price);
            var entity = new Item(item.Product, item.Quantity, newPrice, order.PublicId);
            await _itemRepository.AddAsync(entity);

            order.TotalPrice += newPrice * item.Quantity;
        }

        return order.PublicId;
    }

    public async Task DeleteItemAsync(Guid orderPublicId, Guid itemPublicId)
    {
        var order = await _orderRepository.GetByIdAsync(orderPublicId);

        if (order is null) throw new Exception("Pedido não encontrado");

        var item = await _itemRepository.GetByIdAsync(itemPublicId);

        if (item is null) throw new Exception("Item não encontrado");

        if(!item.OrderPublicId.Equals(order.PublicId)) throw new Exception("Item não pertence ao pedido informado");

        await _itemRepository.DeleteAsync(item);
    }

    public async Task<GetOrderResponseDto> GetByIdAsync(Guid orderPublicId)
    {
        var order = await _orderRepository.GetByIdAsync(orderPublicId);
        var items = await _itemRepository.GetAllByOrderAsync(orderPublicId);

        var response = new GetOrderResponseDto()
        {
            PublicId = order.PublicId
        };
  
        foreach (var item in items)
        {
            var itemDto = new GetItemResponseDto()
            {
                PublicId = item.PublicId,
                Product = item.Product,
                Price = item.Price,
                Quantity = item.Quantity
            };

            response.Items.Add(itemDto);

            response.TotalPrice += item.Price * item.Quantity;
        }
  
        return response;
    }

    public async Task UpdateItemQuantityAsync(Guid orderPublicId, Guid itemPublicId, int quantity)
    {
        if (quantity <= 0) throw new Exception("Quantidade deve ser maior que zero");

        var order = await _orderRepository.GetByIdAsync(orderPublicId);

        if (order is null) throw new Exception("Pedido não encontrado");

        var item = await _itemRepository.GetByIdAsync(itemPublicId);

        if(!item.OrderPublicId.Equals(order.PublicId)) throw new Exception("Item não pertence ao pedido informado");

        if (item is null) throw new Exception("Item não encontrado");

        item.Quantity = quantity;

        await _itemRepository.UpdateAsync(item);
    }

    private void ValidateOrder(CreateOrderRequestDto requestDto)
    {
        if (!requestDto.Items.Any())
            throw new Exception("Pedido deve possuir itens");

        foreach (var item in requestDto.Items)
        {
            if (string.IsNullOrWhiteSpace(item.Product)) throw new Exception("Produto é obrigatório");

            if (item.Quantity <= 0) throw new Exception("Quantidade é inválida");

            if (item.Price <= 0) throw new Exception("Preço é inválido");
        }
    }

    private decimal CalculatePrice(OrderType type, decimal price)
    {
        return type switch
        {
            OrderType.Standard => price,
            OrderType.Express => price * 1.15m,
            OrderType.Subscription => price * 0.90m,
            _ => throw new Exception("Tipo de pedido inválido")
        };   
    }
}
