namespace TechStore.Domain.Entities;

public class Card
{
    public int IdCard { get; set; }
    public string MaskedNumber { get; set; }
    public string PaymentToken { get; set; }
    public string CpfCard { get; set; }
    public string ExpDateCard { get; set; }
    public string TypeCard { get; set; }
    public string NicknameCard { get; set; }
    public string NameOnCard { get; set; }




    public int IdClient { get; set; }
    public Client Client { get; set; }
}
