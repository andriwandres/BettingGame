using BettingGame.Core.Models.Domain;
using BettingGame.Core.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BettingGame.Service.Infrastructure
{
    public class CryptoService : ICryptoService
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string GenerateToken(User user, string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            // Configure claims to build the token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature
                )
            };

            // Create the token
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);
        }

        public bool VerifyPassword(byte[] hash, byte[] salt, string password)
        {
            return hash.SequenceEqual(HashPassword(password, salt));
        }
    }
}
