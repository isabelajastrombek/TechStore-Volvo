namespace TechStore.Application.DTOs;

public class CardCreateDto {
    public int ClientId { get; set; }
    public required string ExpDateCard { get; set; }
    public required string FullNumber { get; set; }
    public required string Cpf { get; set; }
    public required string CVV { get; set; }
    public required string NameOnCard { get; set; }
    public required string TypeCard { get; set; }
    public string NicknameCard {get; set;} = string.Empty;
}