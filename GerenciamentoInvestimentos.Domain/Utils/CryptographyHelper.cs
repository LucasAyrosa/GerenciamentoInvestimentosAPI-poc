using System.Security.Cryptography;
using System.Text;

namespace GerenciamentoInvestimentos.Infrastructure.Utils;

public static class CryptographyHelper
{
    public static string CryptographyPassword(this string password)
    {
        using SHA256 sha256 = SHA256.Create();

        byte[] bytePass = Encoding.UTF8.GetBytes(password);

        byte[] hashBytes = sha256.ComputeHash(bytePass);

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }

        return builder.ToString();
    }
}
