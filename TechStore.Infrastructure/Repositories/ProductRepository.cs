using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceTechContext _context;

    public ProductRepository(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<List<ProductTb>> GetAllAsync(int skip, int take)
    {
        if (take > 50) take = 50;

        return await _context.ProductTbs
            .Include(p => p.IdCategoryNavigation)
            .AsNoTracking()
            .OrderBy(p => p.IdProduct)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<ProductTb?> GetByIdAsync(int id)
    {
        return await _context.ProductTbs
            .Include(p => p.IdCategoryNavigation)
            .FirstOrDefaultAsync(p => p.IdProduct == id);
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
    {
        return await _context.CategoryTbs
            .AnyAsync(c => c.IdCategory == categoryId);
    }

    public async Task AddAsync(ProductTb product)
    {
        _context.ProductTbs.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductTb product)
    {
        _context.ProductTbs.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProductTb product)
    {
        _context.ProductTbs.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ProductTb>> GetByCategoryAsync(string categoryName)
    {
        return await _context.ProductTbs
            .Include(p => p.IdCategoryNavigation)
            .Where(p => p.IdCategoryNavigation.NameCategory.ToLower() == categoryName.ToLower())
            .AsNoTracking()
            .ToListAsync();
    }
}
