namespace TechStore.Application.Interfaces;

public interface IEncryptionService
{
    //Senhas - BCrypt
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);

    // Dados sensíveis - AES
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}