using TechStore.Application.DTOs;
using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientTb>> GetAllAsync();


    Task<bool> AddAddressAsync(AddressCreateDto addressDto);
    Task<IEnumerable<AddressResponseDto>> GetAddressesByClientIdAsync(int clientId);
    

    Task<bool> AddCardAsync(CardCreateDto cardDto);
    Task<IEnumerable<CardResponseDto>> GetCardsByClientIdAsync(int clientId);

    DateOnly ParseExpirationDate(string mmYy);
    
}
