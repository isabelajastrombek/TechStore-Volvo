using TechStore.Application.DTOs;
using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IOrderService
{
    Task<int> CreateOrderAsync(CreateOrderDto dto);
    Task<IEnumerable<OrderTb>> GetAllAsync();
}
