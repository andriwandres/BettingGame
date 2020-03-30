using BettingGame.Core;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Service.Domain
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Game>> GetGames(int phaseId)
        {
            return await _unitOfWork.GameRepository.GetGames(phaseId);
        }
    }
}
