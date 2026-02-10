namespace TechStore.Application.DTOs;

public class OrderDetailsDto
{
    public int OrderId { get; set; }
    public DateTime? DateOrder { get; set; }
    public string Status { get; set; } = string.Empty;
    public int? ClientId { get; set; }
    public int? AddressId { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? TotalShipping { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
