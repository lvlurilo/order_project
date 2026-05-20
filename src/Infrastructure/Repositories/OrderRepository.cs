using OrderApi.src.Domain.Entities;
using OrderApi.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.src.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid publicId)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.PublicId == publicId);
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);

        await _context.SaveChangesAsync();
    }
}