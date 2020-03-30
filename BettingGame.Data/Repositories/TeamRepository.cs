using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class TeamRepository : Repository<BettingGameContext>, ITeamRepository
    {
        public TeamRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task<Team> GetTeam(int teamId)
        {
            return await Context.Teams.SingleOrDefaultAsync(team => team.TeamId == teamId);
        }
    }
}
