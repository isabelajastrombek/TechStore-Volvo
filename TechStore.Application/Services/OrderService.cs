using Microsoft.EntityFrameworkCore;
using TechStore.Domain.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Domain.Services;

public class OrderService : IOrderService
{
    private readonly ECommerceTechContext _context;

    public OrderService(ECommerceTechContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderTb>> GetAllAsync()
    {
        return await _context.OrderTbs.ToListAsync();
    }


// public class PaymentService {
//     public Card GenerateToken(string realCardNumber, int idClient, string cpfCard, string expDate, string TypeCard, string nicknameCard, string nameOnCard) {
        
//         string LastDigits = realCardNumber.Substring(realCardNumber.Length - 4);
        
//         return new Card {
//             IdClient = idClient,
//             MaskedNumber = $"**** **** **** {LastDigits}",
//             CpfCard = cpfCard,
//             ExpDateCard = expDate,
//             TypeCard = TypeCard,
//             NicknameCard = nicknameCard,
//             NameOnCard = nameOnCard,

//             PaymentToken = "TOK_" + Guid.NewGuid().ToString().ToUpper(), 
//         };
//     }
// }




}
