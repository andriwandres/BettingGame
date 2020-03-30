using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int userId);
        Task<bool> EmailExists(string email);
        Task AddUser(User user);
    }
}
