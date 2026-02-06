namespace TechStore.Domain.Entities;

public class ItemOrder
{
    public int IdItemOrder { get; set; }

    public int IdOrder { get; set; }
    public Order Order { get; set; }

    public int IdProduct { get; set; }
    public Product Product { get; set; }

    public int QtyItemOrder { get; set; }
    public decimal PriceUnitItem { get; set; }
}
