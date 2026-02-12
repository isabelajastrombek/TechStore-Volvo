namespace TechStore.Application.DTOs;

public class ProductResponseDto
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public decimal Price { get; set; }
    public required string CategoryName { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Specs { get; set; }  = string.Empty;
    public int Stock { get; set; }
}