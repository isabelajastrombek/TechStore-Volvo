using TechStore.Domain.Entities;

namespace TechStore.Domain.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductTb>> GetAllAsync();
}