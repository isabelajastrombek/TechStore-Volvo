using Microsoft.AspNetCore.Mvc;
using TechStore.Application.DTOs;
using TechStore.Application.Exceptions;
using TechStore.Application.Interfaces;

namespace TechStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    // POST: api/pedidos
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
    {
        try
        {
            var orderId = await _service.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = orderId }, orderId);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BusinessRuleException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/pedidos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderSummaryDto>>> GetAll()
    {
        var orders = await _service.GetAllAsync();
        return Ok(orders);
    }

    // GET: api/pedidos/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailsDto>> GetById(int id)
    {
        try
        {
            var order = await _service.GetByIdAsync(id);
            return Ok(order);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // PATCH: api/pedidos/{id}/status
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateOrderStatusDto dto
    )
    {
        try
        {
            await _service.UpdateStatusAsync(id, dto.Status);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
