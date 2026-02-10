namespace TechStore.Application.DTOs;

public class OrderSummaryDto
{
    public int OrderId { get; set; }
    public DateTime DateOrder { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
}
