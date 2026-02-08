using TechStore.Application.DTOs;
using TechStore.Application.Exceptions;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;

namespace TechStore.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetAllAsync(int skip, int take)
    {
        var products = await _repository.GetAllAsync(skip, take);

        return products.Select(p => new ProductResponseDTO
        {
            Id = p.IdProduct,
            Name = p.NameProduct,
            Price = p.PriceProduct,
            CategoryName = p.IdCategoryNavigation.NameCategory,
            Brand = p.BrandProduct,
            Specs = p.SpecsProduct
        });
    }

    public async Task<ProductResponseDTO> CreateAsync(ProductInsertDto productInsert)
    {
        var categoryExists = await _repository.CategoryExistsAsync(productInsert.IdCategory);
        if (!categoryExists)
            throw new CategoryNotFoundException(productInsert.IdCategory);

        var product = new ProductTb
        {
            NameProduct = productInsert.Name,
            PriceProduct = productInsert.Price,
            StockProduct = productInsert.Stock,
            IdCategory = productInsert.IdCategory,
            DescriptionProduct = productInsert.Description,
            BrandProduct = productInsert.Brand,
            SpecsProduct = productInsert.Specs
        };

        await _repository.AddAsync(product);

        var savedProduct = await _repository.GetByIdAsync(product.IdProduct)!;

        return new ProductResponseDTO
        {
            Id = savedProduct.IdProduct,
            Name = savedProduct.NameProduct,
            Price = savedProduct.PriceProduct,
            CategoryName = savedProduct.IdCategoryNavigation.NameCategory,
            Description = savedProduct.DescriptionProduct,
            Brand = savedProduct.BrandProduct,
            Specs = savedProduct.SpecsProduct
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;

        await _repository.DeleteAsync(product);
        return true;
    }

    public async Task<bool> UpdateStockAsync(int id, int newStock)
    {
        if (newStock < 0) return false;

        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;

        product.StockProduct = newStock;
        await _repository.UpdateAsync(product);
        return true;
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetByCategoryAsync(string categoryName)
    {
        var products = await _repository.GetByCategoryAsync(categoryName);

        return products.Select(p => new ProductResponseDTO
        {
            Id = p.IdProduct,
            Name = p.NameProduct,
            Price = p.PriceProduct,
            CategoryName = p.IdCategoryNavigation.NameCategory,
            Brand = p.BrandProduct,
            Specs = p.SpecsProduct
        });
    }
}
