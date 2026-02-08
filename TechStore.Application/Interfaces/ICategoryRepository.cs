using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryTb>> GetAllAsync();
}
