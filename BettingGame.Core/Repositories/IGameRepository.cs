using BettingGame.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGames(int phaseId);
    }
}
