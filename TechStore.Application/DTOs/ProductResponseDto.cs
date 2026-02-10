namespace TechStore.Application.DTOs;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public decimal Price { get; set; }
    public string CategoryName { get; set; } 
    public string Description { get; set; } 
    public string Brand { get; set; } 
    public string Specs { get; set; }  
    public int Stock { get; set; }
}