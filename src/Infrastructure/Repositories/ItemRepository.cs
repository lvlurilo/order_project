using OrderApi.src.Domain.Entities;
using OrderApi.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.src.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Item item)
    {
        await _context.Items.AddAsync(item);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Item item)
    {
        _context.Items.Remove(item);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Item>> GetAllByOrderAsync(Guid orderPublicId)
    {
        return await _context.Items.Where(x => x.OrderPublicId == orderPublicId).ToListAsync();;
    }

    public async Task<List<Item>> GetAllAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(Guid publicId)
    {
        return await _context.Items.FirstOrDefaultAsync(x => x.PublicId == publicId);
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Items.Update(item);

        await _context.SaveChangesAsync();
    }
}