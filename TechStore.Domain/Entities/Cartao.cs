namespace TechStore.Domain.Entities;

public class Cartao
{
    public int IdCartao { get; set; }
    public string NumeroMascarado { get; set; }
    public string TokenPagamento { get; set; }
    public string CpfCartao { get; set; }
    public string DataExpiracao { get; set; }
    public string TipoCartao { get; set; }
    public string ApelidoCartao { get; set; }
    public string NomeNoCartao { get; set; }




    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }
}
