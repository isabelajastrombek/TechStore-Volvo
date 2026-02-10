using TechStore.Application.DTOs;

namespace TechStore.Application.Interfaces;

public interface IOrderService
{
    Task<int> CreateOrderAsync(CreateOrderDto dto);

    Task<IEnumerable<OrderSummaryDto>> GetAllAsync();

    Task<OrderDetailsDto> GetByIdAsync(int orderId);

    Task UpdateStatusAsync(int orderId, string status);
}
