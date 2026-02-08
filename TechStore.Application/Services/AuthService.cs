using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;

namespace TechStore.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;

    public AuthService(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ClientTb>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
