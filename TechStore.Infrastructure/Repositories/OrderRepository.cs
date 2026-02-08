using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceTechContext _context;

    public OrderRepository(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<List<OrderTb>> GetAllAsync()
    {
        return await _context.OrderTbs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<OrderTb?> GetByIdAsync(int id)
    {
        return await _context.OrderTbs
            .FirstOrDefaultAsync(o => o.IdOrder == id);
    }

    public async Task AddAsync(OrderTb order)
    {
        _context.OrderTbs.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderTb order)
    {
        _context.OrderTbs.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(OrderTb order)
    {
        _context.OrderTbs.Remove(order);
        await _context.SaveChangesAsync();
    }
}
