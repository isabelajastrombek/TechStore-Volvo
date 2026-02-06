
using TechStore.Application.Interfaces; 
using System.Security.Cryptography;
using System.Text;
using System.IO;
using BCrypt.Net;


namespace TechStore.Infrastructure.Security;
public class EncryptionService : IEncryptionService
{
   
    //Chave simétrica p/ AES 256 (32bytes):
    private readonly string _encryptionKey = "v0lv0-t3ch-st0r3-s3cr3t-k3y-2026!"; 

    
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
    }

    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
    

    
    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        using (Aes aes = Aes.Create())
        {
            var key = Encoding.UTF8.GetBytes(_encryptionKey.PadRight(32).Substring(0, 32));
            aes.Key = key;
            aes.GenerateIV(); // Gera um vetor de inicio único para cada criptografia

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                // Escrevemos o IV no início do stream para recuperá-lo na descriptografia
                ms.Write(aes.IV, 0, aes.IV.Length);
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        var buffer = Convert.FromBase64String(cipherText);
        using (Aes aes = Aes.Create())
        {
            var key = Encoding.UTF8.GetBytes(_encryptionKey.PadRight(32).Substring(0, 32));
            aes.Key = key;

            using (var ms = new MemoryStream(buffer))
            {
                byte[] iv = new byte[aes.BlockSize / 8];
                ms.Read(iv, 0, iv.Length); // Lemos o IV que foi salvo no início
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

}