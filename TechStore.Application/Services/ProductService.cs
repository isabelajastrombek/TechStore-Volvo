using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Domain.Services;

public class ProductService : IProductService
{
    private readonly ECommerceTechContext _context;

    public ProductService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductTb>> GetAllAsync()
    {
        return await _context.ProductTbs.ToListAsync();
    }
}
