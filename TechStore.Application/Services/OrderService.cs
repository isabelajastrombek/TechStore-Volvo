using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Domain.Services;

public class OrderService : IOrderService
{
    private readonly ECommerceTechContext _context;

    public OrderService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderTb>> GetAllAsync()
    {
        return await _context.OrderTbs.ToListAsync();
    }


// 




}
