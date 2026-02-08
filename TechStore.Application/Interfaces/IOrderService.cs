using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderTb>> GetAllAsync();
}