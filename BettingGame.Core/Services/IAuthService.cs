using BettingGame.Core.Models.Domain;
using BettingGame.Core.Models.Transfer.Auth;
using System.Threading.Tasks;

namespace BettingGame.Core.Services
{
    public interface IAuthService
    {
        Task<User> GetCurrentUser();
        Task<bool> EmailExists(string email);
        Task<(User user, string token)> Authenticate();
        Task<(User user, string token)> Login(LoginDto credentials);
        Task Register(RegisterDto credentials);
    }
}
