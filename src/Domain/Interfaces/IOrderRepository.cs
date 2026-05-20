using OrderApi.src.Domain.Entities;

namespace OrderApi.src.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid publicId);

    Task<List<Order>> GetAllAsync();

    Task AddAsync(Order order);

    Task UpdateAsync(Order order);

    Task DeleteAsync(Order order);
}