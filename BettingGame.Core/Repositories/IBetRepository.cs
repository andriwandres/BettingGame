using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IBetRepository
    {
        Task<Bet> GetBet(int userId, int gameId);
        Task UpsertBet(Bet bet);
        Task AddBet(Bet bet);
        void UpdateBet(Bet bet);
    }
}
