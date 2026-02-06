namespace TechStore.Domain.Entities;

public class Address
{
    public int IdAddress { get; set; }
    public string StreetAddress { get; set; }
    public string NumberAddress { get; set; }
    public string ComplementAddress { get; set; }
    public string CityAddress { get; set; }
    
    public string StateAddress { get; set; }
    public string TypeAddress { get; set; }


    public int IdClient { get; set; }
    public Client Client { get; set; }
}
