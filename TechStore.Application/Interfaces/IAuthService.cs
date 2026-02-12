using TechStore.Application.DTOs;
using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IAuthService
{
    Task<IEnumerable<ClientTb>> GetAllAsync();

    Task<bool> RegisterAsync(SignUpDto signUp);
    Task<string?> LoginAsync(LogInDto login);

    Task<IEnumerable<AddressResponseDto>> GetAddressesByClientIdAsync(int clientId);
}
