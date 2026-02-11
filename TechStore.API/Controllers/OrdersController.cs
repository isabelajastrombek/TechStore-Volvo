using Microsoft.AspNetCore.Mvc;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;
using TechStore.Application.Exceptions;

namespace TechStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("createOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Dados do pedido não fornecidos.");
        }

        bool order = await _orderService.CreateOrderAsync(dto);

        if (order)
        {
            return Ok(new { message = "Pedido realizado com sucesso!" });
        }
        else
        {
            return BadRequest(new { message = "Erro ao processar o pedido. Verifique estoque ou dados informados." });
        }
    }

    [HttpGet("reports/sales-by-category")]
    public async Task<IActionResult> GetCategoryReport()
    {
        var data = await _orderService.GetSalesByCategoryAsync();
        
        if (data == null || data.Count == 0)
            return NotFound("Nenhuma venda encontrada para gerar o relatório.");

        return Ok(data);
    }


    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetHistory(int clientId)
    {
        var history = await _orderService.GetClientOrderHistoryAsync(clientId);
        
        if (history == null || history.Count == 0)
            return NotFound("Nenhum pedido encontrado para este cliente.");

        return Ok(history);
    }


    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateOrderStatusDto dto
    )
    {
        try
        {
            await _orderService.UpdateStatusAsync(id, dto.Status);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}