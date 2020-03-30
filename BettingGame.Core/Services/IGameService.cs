using BettingGame.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Core.Services
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetGames(int phaseId);
    }
}
