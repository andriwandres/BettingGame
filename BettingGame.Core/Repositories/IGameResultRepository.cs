using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGameResultRepository
    {
        Task<GameResult> GetGameResult(int gameId);
        Task AddGameResult(GameResult result);
    }
}
