namespace TechStore.Application.DTOs;

public class ProductInsertDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int IdCategory { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public string? Specs { get; set; } // O JSON que você populou no banco
}