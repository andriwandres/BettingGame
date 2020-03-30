using BettingGame.Core;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Services;
using System.Threading.Tasks;

namespace BettingGame.Service.Domain
{
    public class GameResultService : IGameResultService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddGameResult(GameResult gameResult)
        {
            await _unitOfWork.GameResultRepository.AddGameResult(gameResult);
            await _unitOfWork.Commit();
        }

        public async Task<GameResult> GetGameResult(int gameId)
        {
            return await _unitOfWork.GameResultRepository.GetGameResult(gameId);
        }
    }
}
