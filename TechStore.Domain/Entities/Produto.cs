namespace TechStore.Domain.Entities;

public class Produto
{
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public decimal PrecoProduto { get; set; }
    public int EstoqueProduto { get; set; }
    public string? DescricaoProduto { get; set; }
    public string? EspecificacaoProduto { get; set; }
    public string? MarcaProduto { get; set; }

    public int IdCategoria { get; set; }
    public Categoria Categoria { get; set; }
}
