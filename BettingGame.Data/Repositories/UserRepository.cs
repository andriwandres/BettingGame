using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class UserRepository : Repository<BettingGameContext>, IUserRepository
    {
        public UserRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task AddUser(User user)
        {
            await Context.Users.AddAsync(user);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await Context.Users.AnyAsync(user => user.Email == email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.SingleOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await Context.Users.SingleOrDefaultAsync(user => user.UserId == userId);
        }
    }
}
