using TechStore.Domain.Entities;

namespace TechStore.Application.Interfaces;

public interface IOrderService
{
    Task<bool> CreateOrderAsync(OrderCreateDto dto);
    Task<List<CategoryReportDto>> GetSalesByCategoryAsync();
    Task<List<OrderHistoryResponseDto>> GetClientOrderHistoryAsync(int clientId);

    Task UpdateStatusAsync(int orderId, string status);
}