using TechStore.Domain.Entities;
using TechStore.Application.DTOs;


namespace TechStore.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDTO>> GetAllAsync(int skip, int take);
    Task<ProductResponseDTO> CreateAsync(ProductInsertDto productInsert);
    Task<IEnumerable<ProductResponseDTO>> GetByCategoryAsync(string categoryName);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateStockAsync(int id, int newStock);

}