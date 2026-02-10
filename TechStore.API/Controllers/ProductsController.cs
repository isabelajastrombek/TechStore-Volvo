using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Infrastructure.Data;
using TechStore.Domain.Entities;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;
using TechStore.Application.Exceptions;


namespace TechStore.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // Para mostrar todos os produtos do BD
    [HttpGet("catalog")]
    public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var products = await _productService.GetAllAsync(skip, take);
        return Ok(products);
    }

    [HttpPost("insert")] // para inserir o produto no BD
    public async Task<ActionResult<ProductResponseDTO>> Create(ProductInsertDto insert)
    {
        try 
        {
            var newProduct = await _productService.CreateAsync(insert);
            return CreatedAtAction(nameof(GetAll), new { id = newProduct.Id }, newProduct);
        }
        catch (CategoryNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro inesperado." });
        }
    }

    [HttpGet("search")] //Para procurar todos os produtos de uma determinada categoria
    public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> SearchByCategory([FromQuery] string categoryName)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
        {
            return BadRequest("O nome da categoria deve ser informado.");
        }

        var products = await _productService.GetByCategoryAsync(categoryName);
        
        if (!products.Any())
        {
            return NotFound($"Nenhum produto encontrado para a categoria '{categoryName}'.");
        }

        return Ok(products);
    }


    [HttpDelete("{id}")] //para deletar o produto de determinado ID
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _productService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return Ok(new { message = $"Sucesso: Produto {id} removido" });
    }


    [HttpPatch("{id}/stock")] // para atualizar o estoque
    public async Task<IActionResult> UpdateStock(int id, [FromBody] ProductStockUpdate stockUpdate)
    {
        var updated = await _productService.UpdateStockAsync(id, stockUpdate.NewStock);

        if (!updated)
        {
            return BadRequest(new { message = "Erro: Produto não encontrado ou quantidade inválida." });
        }

        return Ok(new { message = $"Sucesso: Estoque do produto {id} atualizado para {stockUpdate.NewStock}." });
    }


}

