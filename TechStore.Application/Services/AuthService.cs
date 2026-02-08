using TechStore.Domain.Entities;
using TechStore.Application.Interfaces;
using TechStore.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace TechStore.Domain.Services;

public class AuthService : IAuthService
{
    private readonly ECommerceTechContext _context;

    public AuthService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientTb>> GetAllAsync()
    {
        return await _context.ClientTbs.ToListAsync();
    }
}