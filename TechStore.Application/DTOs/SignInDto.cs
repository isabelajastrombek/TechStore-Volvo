using TechStore.Domain.Entities;

namespace TechStore.Application.DTOs;

public class SignInDto
{
    public string CpfClient { get; set; }
    public string NameClient { get; set; }

    public string BirthDateClient {get; set;}
    public string EmailClient {get; set;}
    public string PasswordClient {get; set;}

    
}