namespace TechStore.Domain.Entities;

public class Order
{
    public int IdOrder { get; set; }
    public DateTime DateOrder { get; set; }
    public int IdClient { get; set; }

    public string StatusOrder { get; set; }

    public DateTime DeliveryDate { get; set; }
    public int idCard { get; set; }
    public int idAddress { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalShipping { get; set; }


    public ICollection<ItemOrder> Items { get; set; }
}
