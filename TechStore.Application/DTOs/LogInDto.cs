using TechStore.Domain.Entities;

namespace TechStore.Application.DTOs;

public class LogInDto
{
    public string EmailClient {get; set;}
    public string PasswordClient {get; set;}
   
}