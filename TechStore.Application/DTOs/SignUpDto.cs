using TechStore.Domain.Entities;

namespace TechStore.Application.DTOs;

public class SignUpDto
{
    public required string CpfClient { get; set; }
    public required string NameClient { get; set; }

    public string BirthDateClient {get; set;} = string.Empty;

    public string PhoneClient {get; set;} = string.Empty;
    public required string EmailClient {get; set;}
    public string PasswordClient {get; set;} = string.Empty;


    
}