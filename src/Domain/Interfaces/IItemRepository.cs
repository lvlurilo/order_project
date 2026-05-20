using OrderApi.src.Domain.Entities;

namespace OrderApi.src.Domain.Interfaces;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid publicId);

    Task<List<Item>> GetAllAsync();

    Task<List<Item>> GetAllByOrderAsync(Guid orderPublicId);

    Task AddAsync(Item item);

    Task UpdateAsync(Item item);

    Task DeleteAsync(Item item);
}