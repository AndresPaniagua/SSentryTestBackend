using Microsoft.Extensions.Options;
using SSentryTestBackend.Infrastructure.Interfaces;
using SSentryTestBackend.Infrastructure.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace SSentryTestBackend.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _options;
        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }
        public bool Check(string hash, string password)
        {
            string[] parts = hash.Split('.');
            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format");
            }

            int iterations = Convert.ToInt32(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] keyToCheck = algorithm.GetBytes(_options.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public string Hash(string password)
        {
            //PBKDF2 Implementation
            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(password, _options.SaltSize, _options.Iterations))
            {
                string key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                string salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_options.Iterations}.{salt}.{key}";
            }
        }
    }
}
