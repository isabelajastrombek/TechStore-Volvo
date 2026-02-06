namespace TechStore.Domain.Entities;

public class Product
{
    public int IdProduct { get; set; }
    public string NameProduct { get; set; }
    public decimal PriceProduct { get; set; }
    public int StockProduct { get; set; }

    public int IdCategory { get; set; }
    
    public string DescriptionProduct { get; set; }
    public string SpecsProduct { get; set; }
    public string BrandProduct { get; set; }
    
    
    public Category Category { get; set; }
}

