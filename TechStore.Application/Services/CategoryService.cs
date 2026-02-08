using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;

namespace TechStore.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryTb>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
