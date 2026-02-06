namespace TechStore.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}

