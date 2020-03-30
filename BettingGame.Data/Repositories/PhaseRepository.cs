using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class PhaseRepository : Repository<BettingGameContext>, IPhaseRepository
    {
        public PhaseRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Phase>> GetPhases()
        {
            return await Context.Phases
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
