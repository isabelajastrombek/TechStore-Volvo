using TechStore.Domain.Entities;
using TechStore.Application.DTOs;


namespace TechStore.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync(int skip, int take);
    Task<ProductResponseDto> CreateAsync(ProductInsertDto productInsert);
    Task<IEnumerable<ProductResponseDto>> GetByCategoryAsync(string categoryName);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateStockAsync(int id, int newStock);
    Task<IEnumerable<ProductResponseDto>> GetProductsAsync(ProductSearchDto filters);

}