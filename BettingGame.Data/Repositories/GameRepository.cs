using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GameRepository : Repository<BettingGameContext>, IGameRepository
    {
        public GameRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Game>> GetGames(int phaseId)
        {
            return await Context.Games
                .AsNoTracking()
                .Where(game => game.PhaseId == phaseId)
                .ToListAsync();
        }
    }
}
