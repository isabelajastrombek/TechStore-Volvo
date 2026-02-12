using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
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

    public async Task<CategoryResponseDto> AddCategoryAsync(CategoryCreateDto dto)
    {
        var category = new CategoryTb 
        { 
            NameCategory = dto.NameCategory
        };

        _context.CategoryTbs.Add(category);
        await _context.SaveChangesAsync();

        return new CategoryResponseDto(
            category.IdCategory, 
            category.NameCategory 
        );
    }
}
