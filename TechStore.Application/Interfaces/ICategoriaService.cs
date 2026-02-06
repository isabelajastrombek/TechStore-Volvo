using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> GetAllAsync();
}
