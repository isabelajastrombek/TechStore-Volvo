using TechStore.Domain.Entities;

namespace TechStore.Domain.Interfaces;

public interface IAuthService
{
    Task<IEnumerable<ClientTb>> GetAllAsync();
}
