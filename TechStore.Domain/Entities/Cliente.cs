namespace TechStore.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }

    public ICollection<Endereco> Enderecos { get; set; }
    public ICollection<Cartao> Cartoes { get; set; }
}
