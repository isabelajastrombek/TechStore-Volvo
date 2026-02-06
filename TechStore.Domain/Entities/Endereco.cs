namespace TechStore.Domain.Entities;

public class Endereco
{
    public int IdEndereco { get; set; }
    public string? LogradouroEndereco { get; set; }
    public string? NumeroEndereco { get; set; }
    public string? ComplementoEndereco { get; set; }
    public string? CidadeEndereco { get; set; }
    public string? EstadoEndereco { get; set; }
    public string? TipoEndereco { get; set; }

    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }
}
