namespace TechStore.Application.DTOs;

public class FreightResponseDto
{
    public decimal Price { get; set; }
    public int DeliveryDays { get; set; }
    public string Company { get; set; } = string.Empty;
}
