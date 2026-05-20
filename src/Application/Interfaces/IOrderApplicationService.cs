using OrderApi.src.Application.Dtos.Order;

namespace OrderApi.src.Application.Interfaces;

public interface IOrderApplicationService
{
    Task<Guid> CreateAsync(CreateOrderRequestDto requestDto);

    Task UpdateItemQuantityAsync(Guid orderId, Guid itemId, int quantity);

    Task DeleteItemAsync(Guid orderPublicId, Guid itemPublicId);

    Task<GetOrderResponseDto> GetByIdAsync(Guid id);
}