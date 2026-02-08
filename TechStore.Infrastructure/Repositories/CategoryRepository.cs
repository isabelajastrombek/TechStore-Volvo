using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ECommerceTechContext _context;

    public CategoryRepository(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryTb>> GetAllAsync()
    {
        return await _context.CategoryTbs
            .AsNoTracking()
            .ToListAsync();
    }
}
