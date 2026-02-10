namespace TechStore.Application.DTOs;

public class OrderResponseDto
{
    public int OrderId { get; set; }
    public DateTime DateOrder { get; set; }
    public string Status { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }
    public decimal TotalShipping { get; set; }

    public int ClientId { get; set; }

    public List<OrderItemDto> Items { get; set; } = new();
}
