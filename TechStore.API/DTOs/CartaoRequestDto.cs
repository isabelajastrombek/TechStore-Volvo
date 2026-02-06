namespace TechStore.API.DTOs;

public class CartaoRequest {
    public string NumeroCompleto { get; set; }
    public string Cpf { get; set; }
    public string CVV { get; set; }
    public string NomeNoCartao { get; set; }
}