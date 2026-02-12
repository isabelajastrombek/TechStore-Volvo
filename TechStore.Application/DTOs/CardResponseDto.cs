public class CardResponseDto
{
    public int IdCard { get; set;}
    public required string MaskedNumber { get; set;}
    public required string CpfCard { get; set;}
    public string NicknameCard { get; set;} = string.Empty;
    
    public required string PaymentToken { get; set;}
    public required string ExpDateCard {get; set;}

}