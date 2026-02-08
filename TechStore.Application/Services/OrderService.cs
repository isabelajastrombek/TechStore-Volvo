using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;

namespace TechStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderTb>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }
}
