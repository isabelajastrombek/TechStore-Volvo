using Microsoft.EntityFrameworkCore;
using TechStore.Application.DTOs;
using TechStore.Application.Exceptions;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly ECommerceTechContext _context;

    public OrderService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<int> CreateOrderAsync(CreateOrderDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var client = await _context.ClientTbs.FindAsync(dto.ClientId);
            if (client == null)
                throw new NotFoundException("Client not found");

            var order = new OrderTb
            {
                DateOrder = DateTime.Now,
                IdClient = dto.ClientId,
                IdAddress = dto.AddressId,
                IdCard = dto.CardId,
                StatusOrder = "Created",
                TotalShipping = 0
            };

            _context.OrderTbs.Add(order);
            await _context.SaveChangesAsync();

            decimal totalValue = 0;

            foreach (var item in dto.Items)
            {
                var product = await _context.ProductTbs.FindAsync(item.ProductId);
                if (product == null)
                    throw new NotFoundException($"Product {item.ProductId} not found");

                if (product.StockProduct < item.Quantity)
                    throw new BusinessRuleException($"Insufficient stock for product {product.NameProduct}");

                product.StockProduct -= item.Quantity;

                var orderItem = new ItemOrderTb
                {
                    IdOrder = order.IdOrder,
                    IdProduct = product.IdProduct,
                    QtyItemOrder = item.Quantity,
                    PriceUnitItem = product.PriceProduct
                };

                totalValue += product.PriceProduct * item.Quantity;

                _context.ItemOrderTbs.Add(orderItem);
            }

            order.TotalPrice = totalValue;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return order.IdOrder;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<OrderTb>> GetAllAsync()
    {
        return await _context.OrderTbs
            .Include(o => o.ItemOrderTbs)
            .ThenInclude(i => i.IdProductNavigation)
            .ToListAsync();
    }

}
