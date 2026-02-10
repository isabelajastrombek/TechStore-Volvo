using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Infrastructure.Data;
using TechStore.Domain.Entities;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;
using TechStore.Application.Exceptions;
using TechStore.Application.Services;


namespace TechStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IOrderService _service;

        public PedidosController(IOrderService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            try
            {
                var idOrder = await _service.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(CreateOrder), new { id = idOrder }, idOrder);
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
    }
}