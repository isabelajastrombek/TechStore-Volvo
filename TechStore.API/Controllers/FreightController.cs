using Microsoft.AspNetCore.Mvc;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;

namespace TechStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FreightController : ControllerBase
{
    private readonly IFreightService _freightService;

    public FreightController(IFreightService freightService)
    {
        _freightService = freightService;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate(FreightRequestDto dto)
    {
        var result = await _freightService.CalculateAsync(dto);
        return Ok(result);
    }
}
