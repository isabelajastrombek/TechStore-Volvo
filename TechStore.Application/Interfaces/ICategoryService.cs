using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryTb>> GetAllAsync();
    Task<CategoryResponseDto> AddCategoryAsync(CategoryCreateDto categoryDto);
}
