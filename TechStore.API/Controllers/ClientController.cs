using Microsoft.AspNetCore.Mvc;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;

namespace TechStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }


    [HttpPost("addresses")]
    public async Task<IActionResult> AddAddress([FromBody] AddressCreateDto addressDto)
    {
        var newAddress = await _clientService.AddAddressAsync(addressDto);

        if (!newAddress)
            return BadRequest(new { message = "Não foi possível adicionar o endereço." });

        return Ok(new { message = "Endereço adicionado" });
    }


    [HttpGet("{clientId}/addresses")]
    public async Task<IActionResult> GetAddresses(int clientId)
    {
        var addresses = await _clientService.GetAddressesByClientIdAsync(clientId);

        if (addresses == null)
            return NotFound(new { message = "Nenhum endereço encontrado para esse cliente." });

        return Ok(addresses);
    }



    [HttpPost("addCard")]
    public async Task<IActionResult> AddCard([FromBody] CardCreateDto cardDto)
    {
        var newCard = await _clientService.AddCardAsync(cardDto);

        if (newCard == false)
        {
            return BadRequest(new { message = "Não foi possível adicionar o cartão." });
        }

        return Ok(new { message = "Cartão registrado" });
    }


    [HttpGet("{clientId}/cards")]
    public async Task<IActionResult> GetCards(int clientId)
    {
        var cards = await _clientService.GetCardsByClientIdAsync(clientId);

        if (cards == null)
        {
            return NotFound(new { message = "Não há nenhum cartão registrado para esse cliente." });
        }

        return Ok(cards);
    }



}