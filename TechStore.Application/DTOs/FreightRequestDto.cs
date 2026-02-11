namespace TechStore.Application.DTOs;

public class FreightRequestDto
{
    public string FromZipCode { get; set; } = string.Empty;
    public string ToZipCode { get; set; } = string.Empty;

    public decimal WeightKg { get; set; }

    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Length { get; set; }

    public int Quantity { get; set; }
}
