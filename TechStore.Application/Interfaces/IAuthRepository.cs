using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IAuthRepository
{
    Task<IEnumerable<ClientTb>> GetAllAsync();
}
