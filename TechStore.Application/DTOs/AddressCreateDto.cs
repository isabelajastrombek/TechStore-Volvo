namespace TechStore.Application.DTOs;

public class AddressCreateDto
{
    public int ClientId { get; set; }
    public required string StreetAddress { get; set; } 
    public required string NumberAddress { get; set; }
    public string ComplementAddress { get; set; } = string.Empty;
    public required string CityAddress { get; set; }
    public required string StateAddress { get; set; }
    public string TypeAddress { get; set; } = string.Empty;
    public required string CepAddress { get; set; }

}