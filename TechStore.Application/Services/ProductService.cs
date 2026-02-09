using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;
using TechStore.Application.DTOs;
using TechStore.Application.Exceptions;


namespace TechStore.Application.Services;

public class ProductService : IProductService
{
    private readonly ECommerceTechContext _context;

    public ProductService(ECommerceTechContext context)
    {
        _context = context;
    }

   public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(int skip, int take)
    {
        if (take > 50) take = 50; 

        return await _context.ProductTbs
            .Include(p => p.IdCategoryNavigation)
            .AsNoTracking()
            .OrderBy(p => p.IdProduct) 
            .Skip(skip)                
            .Take(take)                
            .Select(p => new ProductResponseDto
            {
                Id = p.IdProduct,
                Name = p.NameProduct,
                Price = p.PriceProduct,
                CategoryName = p.IdCategoryNavigation.NameCategory,
                Brand = p.BrandProduct,
                Specs = p.SpecsProduct
            })
            .ToListAsync();
    }

    public async Task<ProductResponseDto> CreateAsync(ProductInsertDto productInsert)
    {

        var categoryExists = await _context.CategoryTbs
                .AnyAsync(c => c.IdCategory == productInsert.IdCategory);

            if (!categoryExists)
            {
                throw new CategoryNotFoundException(productInsert.IdCategory);
            }


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

        _context.ProductTbs.Add(product);
        await _context.SaveChangesAsync();

        var savedProduct = await _context.ProductTbs
        .Include(p => p.IdCategoryNavigation)
        .FirstAsync(p => p.IdProduct == product.IdProduct);
        return new ProductResponseDto 
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

    public async Task<IEnumerable<ProductResponseDto>> GetByCategoryAsync(string categoryName)
    {
        return await _context.ProductTbs
            .Include(p => p.IdCategoryNavigation)
            .Where(p => p.IdCategoryNavigation.NameCategory.ToLower() == categoryName.ToLower())
            .AsNoTracking()
            .Select(p => new ProductResponseDto
            {
                Id = p.IdProduct,
                Name = p.NameProduct,
                Price = p.PriceProduct,
                CategoryName = p.IdCategoryNavigation.NameCategory,
                Brand = p.BrandProduct,
                Specs = p.SpecsProduct
            })
            .ToListAsync();
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.ProductTbs.FindAsync(id);
        
        if (product == null)
        {
            return false; 
        }

        _context.ProductTbs.Remove(product);
        await _context.SaveChangesAsync();
        
        return true; 
    }


    public async Task<bool> UpdateStockAsync(int id, int newStock)
    {
        var product = await _context.ProductTbs.FindAsync(id);
        
        if (product == null) {return false;}

        else if (newStock < 0) {return false;}

        else
        {
            product.StockProduct = newStock;
        
            _context.ProductTbs.Update(product);
            await _context.SaveChangesAsync();
            
            return true; 
        }

        
    }



    public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync(ProductSearchDto searchDto)
    {
        
        IQueryable<ProductTb> query = _context.ProductTbs
            .Include(p => p.IdCategoryNavigation);

        if (!string.IsNullOrEmpty(searchDto.Name))
            query = query.Where(p => p.NameProduct.Contains(searchDto.Name));

        if (searchDto.MinPrice > 0)
            query = query.Where(p => p.PriceProduct >= searchDto.MinPrice);

        if (searchDto.MaxPrice > 0)
            query = query.Where(p => p.PriceProduct <= searchDto.MaxPrice);

        if (!string.IsNullOrEmpty(searchDto.CategoryName))
            query = query.Where(p => p.IdCategoryNavigation.NameCategory.Contains(searchDto.CategoryName));

        if (!string.IsNullOrEmpty(searchDto.Brand))
            query = query.Where(p => p.BrandProduct.Contains(searchDto.Brand));

        var products = await query.ToListAsync();

        return products.Select(p => new ProductResponseDto
        {
            Id = p.IdProduct,
            Name = p.NameProduct,
            Price = p.PriceProduct,
            Description = p.DescriptionProduct,
            CategoryName = p.IdCategoryNavigation?.NameCategory,
            Brand = p.BrandProduct,
            Specs = p.SpecsProduct 
        });
    }



}
