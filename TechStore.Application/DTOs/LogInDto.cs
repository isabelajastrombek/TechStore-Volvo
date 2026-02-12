using TechStore.Domain.Entities;

namespace TechStore.Application.DTOs;

public class LogInDto
{
    public required string EmailClient {get; set;}
    public required string PasswordClient {get; set;}
   
}