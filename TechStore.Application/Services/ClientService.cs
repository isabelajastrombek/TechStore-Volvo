using TechStore.Domain.Entities;
using TechStore.Application.Interfaces;

using TechStore.Infrastructure.Data;
using BCrypt.Net;

using Microsoft.EntityFrameworkCore;
using TechStore.Application.DTOs;

namespace TechStore.Application.Services;

public class ClientService : IClientService
{
    private readonly ECommerceTechContext _context;

    public ClientService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientTb>> GetAllAsync()
    {
        return await _context.ClientTbs.ToListAsync();
    }


    public async Task<bool> AddAddressAsync(AddressCreateDto addressDto)
    {
        var clientExists = await _context.ClientTbs.AnyAsync(c => c.IdClient == addressDto.ClientId);
        if (!clientExists) return false;

        var newAddress = new AddressTb
        {
            IdClient = addressDto.ClientId,
            StreetAddress = addressDto.StreetAddress,
            NumberAddress = addressDto.NumberAddress,
            ComplementAddress = addressDto.ComplementAddress,
            CityAddress = addressDto.CityAddress,
            StateAddress = addressDto.StateAddress,
            TypeAddress = addressDto.TypeAddress
        };

        _context.AddressTbs.Add(newAddress);
        await _context.SaveChangesAsync();
        return true;
    }
        
    public async Task<IEnumerable<AddressResponseDto>> GetAddressesByClientIdAsync(int clientId)
    {
        var Client = await _context.ClientTbs
            .Include(c => c.AddressTbs) 
            .FirstOrDefaultAsync(c => c.IdClient == clientId);

        if (Client == null) return Enumerable.Empty<AddressResponseDto>();

        return Client.AddressTbs.Select(a => new AddressResponseDto
        {
            IdAddress = a.IdAddress,
            TypeAddress = a.TypeAddress,
            StreetAddress = a.StreetAddress,
            NumberAddress = a.NumberAddress,
            ComplementAddress = a.ComplementAddress,
            CityAddress = a.CityAddress,
            StateAddress = a.StateAddress
        });
    }


    public async Task<bool> AddCardAsync(CardCreateDto cardDto)
    {
        var client = await _context.ClientTbs.FindAsync(cardDto.ClientId);
        if (client == null) return false;

        // mascara o número do cartão 
        string lastDigits = cardDto.FullNumber.Substring(cardDto.FullNumber.Length - 4); //pega os 4 últimos números

        var newCard = new CardTb
        {
            IdClient = cardDto.ClientId,
            MaskedNumber = $"**** **** **** {lastDigits}",
            
            ExpDateCard = ParseExpirationDate(cardDto.ExpDateCard), 
            
            TypeCard = cardDto.TypeCard,
            NicknameCard = cardDto.NicknameCard,
            NameOnCard = cardDto.NameOnCard,
            CpfCard = cardDto.Cpf,
            
            // gera o token
            PaymentToken = "TOK_" + Guid.NewGuid().ToString().ToUpper(),
        };

        _context.CardTbs.Add(newCard);
        await _context.SaveChangesAsync();
        
        return true;
    }


    public async Task<IEnumerable<CardResponseDto>> GetCardsByClientIdAsync(int clientId)
    {
        var cards = await _context.CardTbs
            .Where(c => c.IdClient == clientId)
            .ToListAsync();

        if (!cards.Any()) return null;

        return cards.Select(c => new CardResponseDto
        {
            IdCard = c.IdCard,
            MaskedNumber = c.MaskedNumber,
            NicknameCard = c.NicknameCard,
            PaymentToken = c.PaymentToken,
            CpfCard = c.CpfCard,
            ExpDateCard = c.ExpDateCard.ToString("MM/yy")
        });
    }





    public DateOnly ParseExpirationDate(string mmYy)
    {
        if (DateTime.TryParseExact(mmYy, new[] { "MM/yy", "MM/yyyy" }, 
            System.Globalization.CultureInfo.InvariantCulture, 
            System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
        {
            int lastDay = DateTime.DaysInMonth(parsedDate.Year, parsedDate.Month);
            
            return new DateOnly(parsedDate.Year, parsedDate.Month, lastDay);
        }

        throw new ArgumentException("Formato de data inválido. Use MM/YY.");
    }


}