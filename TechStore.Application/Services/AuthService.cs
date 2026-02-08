using TechStore.Domain.Entities;
using TechStore.Application.Interfaces;
using TechStore.Application.Services.Security;

using TechStore.Infrastructure.Data;
using BCrypt.Net;

using Microsoft.EntityFrameworkCore;
using TechStore.Application.DTOs;

namespace TechStore.Application.Services;

public class AuthService : IAuthService
{
    private readonly ECommerceTechContext _context;
    private readonly IEncryptionService _encryptionService;

    public AuthService(ECommerceTechContext context, IEncryptionService encryptionService)
    {
        _context = context;
        _encryptionService = encryptionService;
    }

    public async Task<IEnumerable<ClientTb>> GetAllAsync()
    {
        return await _context.ClientTbs.ToListAsync();
    }

    public async Task<bool> RegisterAsync(SignUpDto signUp)
    {
        // verifica se já não tem no banco o email
        var exists = await _context.ClientTbs.AnyAsync(c => c.EmailClient == signUp.EmailClient);
        if (exists) return false;

        // cria o cadastro usando o EncryptionService
        var newClient = new ClientTb
        {
            NameClient = signUp.NameClient,
            EmailClient = signUp.EmailClient,
             
            PasswordClient = _encryptionService.HashPassword(signUp.PasswordClient),
            
            CpfClient = _encryptionService.Encrypt(signUp.CpfClient) 
        };

        _context.ClientTbs.Add(newClient);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<string?> LoginAsync(LogInDto login)
    {
        // verifica se encontra o email
        var Client = await _context.ClientTbs
            .FirstOrDefaultAsync(c => c.EmailClient == login.EmailClient);

        if (Client == null) return null; 

        bool isPasswordValid = _encryptionService.VerifyPassword(login.PasswordClient, Client.PasswordClient);

        if (!isPasswordValid) return null;

        return Client.NameClient; 
    }



    public async Task<IEnumerable<AddressResponseDto>> GetAddressesByClientIdAsync(int clientId)
{
    var Client = await _context.ClientTbs
        .Include(c => c.AddressTbs) // Assuming 'AddressTbs' is your navigation property
        .FirstOrDefaultAsync(c => c.IdClient == clientId);

    if (Client == null) return Enumerable.Empty<AddressResponseDto>();

    return Client.AddressTbs.Select(a => new AddressResponseDto
    {
        TypeAddress = a.TypeAddress,
        StreetAddress = a.StreetAddress,
        NumberAddress = a.NumberAddress,
        ComplementAddress = a.ComplementAddress,
        CityAddress = a.CityAddress,
        StateAddress = a.StateAddress
    });
}



}