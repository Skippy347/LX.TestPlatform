using System.Security.Cryptography;
using System.Text;

namespace LX.TestPlatform.Helpers;

public class HashPasswordHelper
{
    public static string HashPassword(string password)
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        using (var sha256 = SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[passwordBytes.Length + salt.Length];

            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            var hashedBytes = sha256.ComputeHash(saltedPassword);

            var hash = new StringBuilder();
            foreach (var b in hashedBytes)
            {
                hash.AppendFormat("{0:x2}", b);
            }

            hash.Append(":");
            hash.Append(Convert.ToBase64String(salt));

            return hash.ToString();
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var hashParts = hashedPassword.Split(':');
        if (hashParts.Length != 2)
        {
            return false;
        }

        var salt = Convert.FromBase64String(hashParts[1]);

        using (var sha256 = SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[passwordBytes.Length + salt.Length];

            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            var hashedBytes = sha256.ComputeHash(saltedPassword);

            var hash = new StringBuilder();
            foreach (var b in hashedBytes)
            {
                hash.AppendFormat("{0:x2}", b);
            }

            return string.Equals(hash.ToString(), hashParts[0], StringComparison.OrdinalIgnoreCase);
        }
    }
}