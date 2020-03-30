using BettingGame.Core.Models.Domain;

namespace BettingGame.Core.Services
{
    public interface ICryptoService
    {
        string GenerateToken(User user, string secret);
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
        bool VerifyPassword(byte[] hash, byte[] salt, string password);
    }
}
