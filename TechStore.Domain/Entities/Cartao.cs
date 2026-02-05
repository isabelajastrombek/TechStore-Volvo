namespace TechStore.Domain.Entities;

public class Cartao
{
    public int Id { get; set; }
    public string NumeroCartao { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
