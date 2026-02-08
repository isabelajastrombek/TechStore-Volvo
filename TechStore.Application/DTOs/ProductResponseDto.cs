namespace TechStore.Application.DTOs;

public class ProductResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Specs { get; set; } = string.Empty; 
}