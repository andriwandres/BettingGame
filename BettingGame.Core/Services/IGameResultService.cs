using BettingGame.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingGame.Core.Services
{
    public interface IGameResultService
    {
        Task<GameResult> GetGameResult(int gameId);
        Task AddGameResult(GameResult gameResult);
    }
}
