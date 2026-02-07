using TechStore.Domain.Entities;

namespace TechStore.Domain.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderTb>> GetAllAsync();
}