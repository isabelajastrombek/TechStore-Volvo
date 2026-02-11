using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly ECommerceTechContext _context;
    private readonly IShippingService _shippingService; 

    public OrderService(ECommerceTechContext context, IShippingService shippingService)
    {
        _context = context;
        _shippingService = shippingService;
    }

    public async Task<bool> CreateOrderAsync(OrderCreateDto dto)
    {
        var address = await _context.AddressTbs.FindAsync(dto.AddressId);
        if (address == null) throw new Exception("Endereço não encontrado."); //confere se endereço está no banco

        decimal totalWeight = 0; 
        foreach (var item in dto.Items)
        {
            var product = await _context.ProductTbs.FindAsync(item.ProductId); //busca produtos
            if (product != null)
            {
                decimal itemWeight = product.WeightProduct ?? 0.5m; //caso esteja sem peso recebe 0.5
                totalWeight += itemWeight * item.Quantity;
            }
        }

        // calculamos frete
        decimal shippingFee = await _shippingService.CalculateShippingAsync(address.Cep, totalWeight);

        using var transaction = await _context.Database.BeginTransactionAsync(); 
        try
        {
            var newOrder = new OrderTb
            {
                IdClient = dto.ClientId,
                IdCard = dto.CardId,
                IdAddress = dto.AddressId,
                DateOrder = DateTime.Now,
                StatusOrder = "Pendente",
                TotalShipping = shippingFee,
                TotalPrice = 0 
            };

            _context.OrderTbs.Add(newOrder);
            await _context.SaveChangesAsync();

            decimal productsSum = 0;

            foreach (var item in dto.Items)
            {
                var product = await _context.ProductTbs.FindAsync(item.ProductId);
                
                if (product == null || product.StockProduct < item.Quantity)
                    throw new Exception("Erro no estoque");

                product.StockProduct -= item.Quantity;
                productsSum += product.PriceProduct * item.Quantity;

                var itemPedido = new ItemOrderTb
                {
                    IdOrder = newOrder.IdOrder,
                    IdProduct = item.ProductId,
                    QtyItemOrder = item.Quantity,
                    PriceUnitItem = product.PriceProduct
                };
                _context.ItemOrderTbs.Add(itemPedido);
            }

            decimal discountValue = 0;
            if (!string.IsNullOrEmpty(dto.CouponCode))
            {
                var coupon = await _context.CouponTbs.FirstOrDefaultAsync(c => c.Code == dto.CouponCode && c.IsActive == true); //procura cupon no banco

                if (coupon != null && coupon.ExpirationDate >= DateTime.Now) //se ainda estiver na validade
                {
                    discountValue = productsSum * (coupon.DiscountPercentage / 100);
                    newOrder.IdCoupon = coupon.IdCoupon;

                } else {throw new Exception("Cupom inválido");}
            }

            newOrder.TotalPrice = (productsSum - discountValue) + shippingFee;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"Erro ao criar pedido: {ex.Message}");
            return false;
        }
    }

    public async Task<List<CategoryReportDto>> GetSalesByCategoryAsync()
    {
        var report = await _context.ItemOrderTbs
            .Include(i => i.IdProductNavigation) // do item vai p/ produto
            .ThenInclude(p => p.IdCategoryNavigation) // do produto vai p/ categoria
            .GroupBy(i => i.IdProductNavigation.IdCategoryNavigation.NameCategory) // junta os itens por categoria
            .Select(group => new CategoryReportDto
            {
                CategoryName = group.Key, // pega só o nome da categoria
                TotalSold = group.Sum(i => i.QtyItemOrder * i.PriceUnitItem) // pega os itens e multiplica os preços pela quantidade
            })
            .OrderByDescending(x => x.TotalSold)
            .ToListAsync();

        return report;
    }



    public async Task<List<OrderHistoryResponseDto>> GetClientOrderHistoryAsync(int clientId)
{
    var orders = await _context.OrderTbs
        .Where(o => o.IdClient == clientId)
        .Include(o => o.IdCouponNavigation)
        .Include(o => o.ItemOrderTbs)   
            .ThenInclude(i => i.IdProductNavigation) 
        .OrderByDescending(o => o.DateOrder) 
        .Select(o => new OrderHistoryResponseDto
        {
            IdOrder = o.IdOrder,
            DateOrder = o.DateOrder,
            StatusOrder = o.StatusOrder,
            TotalPrice = o.TotalPrice,
            TotalShipping = o.TotalShipping,
            CouponCode = o.IdCouponNavigation != null ? o.IdCouponNavigation.Code : "Nenhum",
            Items = o.ItemOrderTbs.Select(i => new OrderItemHistoryDto
            {
                ProductName = i.IdProductNavigation.NameProduct,
                Qty = i.QtyItemOrder ?? 0,
                PriceUnit = i.PriceUnitItem ?? 0
            }).ToList()
        })
        .ToListAsync();

    return orders;
}

    public async Task UpdateStatusAsync(int orderId, string status)
    {
        var order = await _context.OrderTbs.FindAsync(orderId);

        if (order == null)
            throw new NotFoundException("Order not found");

        order.StatusOrder = status;
        await _context.SaveChangesAsync();
    }






}
