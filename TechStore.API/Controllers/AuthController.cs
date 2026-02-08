using Microsoft.AspNetCore.Mvc;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;

namespace TechStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] SignUpDto signUpDto)
    {
        var Cadastro = await _authService.RegisterAsync(signUpDto);

        if (!Cadastro)
        {
            return BadRequest(new { message = "Não foi possível realizar o cadastro. Verifique os dados ou se o usuário já existe." });
        }

        return Ok(new { message = "Usuário cadastrado com sucesso." });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
    {
        var Login = await _authService.LoginAsync(logInDto);

        if (Login == null)
        {
            return Unauthorized(new { message = "E-mail ou senha inválidos." });
        }

        return Ok(new { 
            message = $"Seja bem vindo, {Login} !",
        });
    }

    // para listar todos os clientes
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var Clients = await _authService.GetAllAsync();
        return Ok(Clients);
    }
}