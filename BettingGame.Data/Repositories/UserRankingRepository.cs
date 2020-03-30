using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class UserRankingRepository : Repository<BettingGameContext>, IUserRankingRepository
    {
        public UserRankingRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task AddRanking(UserRanking ranking)
        {
            await Context.UserRankings.AddAsync(ranking);
        }

        public async Task<UserRanking> GetRanking(int userId)
        {
            return await Context.UserRankings.SingleOrDefaultAsync(ranking => ranking.UserId == userId);
        }

        public async Task<IEnumerable<UserRanking>> GetRankings()
        {
            return await Context.UserRankings
                .AsNoTracking()
                .ToListAsync();
        }

        public void UpdateRanking(UserRanking ranking)
        {
            Context.UserRankings.Update(ranking);
        }

        public async Task UpsertRanking(UserRanking ranking)
        {
            bool rankingExists = await Context.UserRankings.AnyAsync(r => r.UserId == ranking.UserId);

            if (rankingExists)
            {
                UpdateRanking(ranking);
            }
            else
            {
                await AddRanking(ranking);
            }
        }
    }
}
