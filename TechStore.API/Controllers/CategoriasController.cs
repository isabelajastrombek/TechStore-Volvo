// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using TechStore.Infrastructure.Data;
// using TechStore.Domain.Entities;

// namespace TechStore.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class CategoriasController : ControllerBase
//     {
//         private readonly AppDbContext _context;

//         public CategoriasController(AppDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/categorias
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
//         {
//             return await _context.Categorias.ToListAsync();
//         }

//         // POST: api/categorias
//         [HttpPost]
//         public async Task<ActionResult<Categoria>> Create(Categoria categoria)
//         {
//             _context.Categorias.Add(categoria);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetAll), new { id = categoria.Id }, categoria);
//         }
//     }
// }
