// using TechStore.Domain.Entities;

// namespace TechStore.Application.Services;

// public class PaymentService
// {
//     public Card GenerateToken(
//         string realCardNumber,
//         int idClient,
//         string cpfCard,
//         string expDate,
//         string typeCard,
//         string nicknameCard,
//         string nameOnCard)
//     {
//         string lastDigits = realCardNumber.Substring(realCardNumber.Length - 4);

//         return new Card
//         {
//             IdClient = idClient,
//             MaskedNumber = $"**** **** **** {lastDigits}",
//             CpfCard = cpfCard,
//             ExpDateCard = expDate,
//             TypeCard = typeCard,
//             NicknameCard = nicknameCard,
//             NameOnCard = nameOnCard,
//             PaymentToken = "TOK_" + Guid.NewGuid().ToString().ToUpper()
//         };
//     }
// }
