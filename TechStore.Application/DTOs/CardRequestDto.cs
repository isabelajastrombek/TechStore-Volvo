namespace TechStore.Application.DTOs;

public class CardRequest {
    public string FullNumber { get; set; }
    public string Cpf { get; set; }
    public string CVV { get; set; }
    public string NameOnCard { get; set; }
}