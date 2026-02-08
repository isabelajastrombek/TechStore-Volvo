using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IOrderRepository
{
    Task<List<OrderTb>> GetAllAsync();
    Task<OrderTb?> GetByIdAsync(int id);
    Task AddAsync(OrderTb order);
    Task UpdateAsync(OrderTb order);
    Task DeleteAsync(OrderTb order);
}
