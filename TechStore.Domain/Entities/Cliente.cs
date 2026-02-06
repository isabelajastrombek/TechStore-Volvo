namespace TechStore.Domain.Entities;

public class Cliente
{
    public int IdCliente { get; set; }
    public string CpfCliente { get; set; }
    public string? NomeCliente { get; set; }
    public DateTime? DataNascimentoCliente { get; set; }
    public string? EmailCliente { get; set; }
    public string? SenhaCliente { get; set; }

    // Navegação
    public ICollection<Endereco> Enderecos { get; set; }
    public ICollection<Pedido> Pedidos { get; set; }
}
