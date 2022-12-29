using System.Security.Cryptography;
using System.Text;
using StudyPro.Models.Interfaces.Cryptography;

namespace StudyPro.Services.Cryptography;

public class HashProvider : IHasher
{
    private const int SaltSize = 32;

    public string Salt
    {
        get
        {
            using var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltSize];

            rng.GetBytes(salt);
            return Encoding.UTF8.GetString(salt, 0, salt.Length);
        }
    }

    public string Hash(string content, string salt)
    {
        var data = Encoding.UTF8.GetBytes(content);
        var buffer = Encoding.UTF8.GetBytes(salt);

        using var hmac = new HMACSHA256(buffer);
        var hash = hmac.ComputeHash(data);
        return Encoding.UTF8.GetString(hash, 0, hash.Length);
    }
}