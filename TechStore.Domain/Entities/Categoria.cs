namespace TechStore.Domain.Entities;

public class Category
{
    public int IdCategory { get; set; }
    public string NameCategory { get; set; }

    public ICollection<Product> Products { get; set; }
}
