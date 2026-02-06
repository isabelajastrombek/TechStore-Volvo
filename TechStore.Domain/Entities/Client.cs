namespace TechStore.Domain.Entities;

public class Client
{
    public int IdClient { get; set; }
    public string CpfClient { get; set; }
    public string NameClient { get; set; }

    public string BirthDateClient {get; set;}

    public string EmailClient {get; set;}
    public string PasswordClient {get; set;}

    public ICollection<Address> Addresses { get; set; }
    public ICollection<Card> Cards { get; set; }
}
