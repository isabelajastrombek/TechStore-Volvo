namespace TechStore.Application.DTOs;

public class AddressCreateDto
{
    public int ClientId { get; set; }
    public string StreetAddress { get; set; }
    public string NumberAddress { get; set; }
    public string ComplementAddress { get; set; }
    public string CityAddress { get; set; }
    public string StateAddress { get; set; }
    public string TypeAddress { get; set; }
    public string CepAddress { get; set; }

}