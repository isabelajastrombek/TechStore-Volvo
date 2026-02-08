using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IAuthService
{
    Task<IEnumerable<ClientTb>> GetAllAsync();
}
