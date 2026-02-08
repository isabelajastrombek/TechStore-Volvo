using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Infrastructure.Data;
using TechStore.Domain.Entities;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ECommerceTechContext _context;

        public CategoriesController(ECommerceTechContext context)
        {
            _context = context;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTb>>> GetAll()
        {
            return await _context.CategoryTbs.ToListAsync();
        }

        // POST: api/categorias
        [HttpPost]
        public async Task<ActionResult<CategoryTb>> Create(CategoryTb category)
        {
            _context.CategoryTbs.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = category.IdCategory }, category);
        }
    }
}
