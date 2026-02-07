// using Microsoft.EntityFrameworkCore;
// using TechStore.Application.Interfaces;
// using TechStore.Domain.Entities;
// using TechStore.Infrastructure.Data;

// namespace TechStore.Application.Services;

// public class CategoryService : ICategoryService
// {
//     private readonly AppDbContext _context;

//     public CategoryService(AppDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<IEnumerable<Category>> GetAllAsync()
//     {
//         return await _context.Categories.ToListAsync();
//     }
// }
