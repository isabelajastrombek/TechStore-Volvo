namespace TechStore.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public string NomeCliente { get; set; }

    public ICollection<ItemPedido> Itens { get; set; }
}
