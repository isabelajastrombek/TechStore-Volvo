namespace TechStore.Application.DTOs;

public class CardCreateDto {
    public int ClientId { get; set; }
    public string ExpDateCard { get; set; }
    public string FullNumber { get; set; }
    public string Cpf { get; set; }
    public string CVV { get; set; }
    public string NameOnCard { get; set; }
    public string TypeCard { get; set; }
    public string NicknameCard {get; set;}
}