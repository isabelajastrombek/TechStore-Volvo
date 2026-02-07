using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ECommerceTechContext _context;

    public CategoryService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryTb>> GetAllAsync()
    {
        return await _context.CategoryTbs.ToListAsync();
    }
}
