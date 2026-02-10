using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Infrastructure.Data;
using TechStore.Domain.Entities;
using TechStore.Application.Interfaces;


namespace TechStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        // O ASP.NET injeta o service automaticamente aqui
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("allCategories")]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost("addCategories")]
        public async Task<ActionResult<CategoryResponseDto>> Create([FromBody] CategoryCreateDto dto)
        {
            var category = await _service.AddCategoryAsync(dto);

            return Ok(new 
                { 
                    message = "Categoria criada com sucesso!", 
                    data = category 
                });    
        }
    }
}
