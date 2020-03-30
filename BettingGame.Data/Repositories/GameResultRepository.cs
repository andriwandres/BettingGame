using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GameResultRepository : Repository<BettingGameContext>, IGameResultRepository
    {
        public GameResultRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task AddGameResult(GameResult result)
        {
            await Context.GameResults.AddAsync(result);
        }

        public async Task<GameResult> GetGameResult(int gameId)
        {
            return await Context.GameResults
                .AsNoTracking()
                .SingleOrDefaultAsync(result => result.GameId == gameId);
        }
    }
}
