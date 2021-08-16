using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System;

namespace WorkoutApi.Util
{

    public sealed class HashingOptions
    {
        public int Iterations { get; set; } = 10000;
    }

    public sealed class PasswordHandler : IPasswordHandler
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private HashingOptions Options { get; }

        public PasswordHandler(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }
        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            /* Keep some check of hash version to see if it needs upgrade*/

            var parts = hash.Split('.', 2);
            var iterations = int.Parse(parts[0]);

            var base64Hash = parts[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var algorithm = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] passwordHash = algorithm.GetBytes(KeySize);

            for (var i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != passwordHash[i])
                {
                    return (false, false);
                }
            }
            return (true, false);

        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Options.Iterations,
                HashAlgorithmName.SHA512
            ))
            {

                var hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(algorithm.Salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(algorithm.GetBytes(KeySize), 0, hashBytes, SaltSize, KeySize);

                var base64Hash = Convert.ToBase64String(hashBytes);

                return $"{Options.Iterations}.{base64Hash}";
            }
        }
    }
}