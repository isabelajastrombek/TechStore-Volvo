// namespace TechStore.Application.Services;

// using TechStore.Domain.Entities;
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