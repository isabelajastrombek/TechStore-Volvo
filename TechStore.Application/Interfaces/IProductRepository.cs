using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IProductRepository
{
    Task<ProductTb?> GetByIdAsync(int id);
    Task<List<ProductTb>> GetAllAsync();
    Task AddAsync(ProductTb product);
    Task UpdateAsync(ProductTb product);
    Task DeleteAsync(ProductTb product);
}
