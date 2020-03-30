using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class BetRepository : Repository<BettingGameContext>, IBetRepository
    {
        public BetRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task AddBet(Bet bet)
        {
            await Context.Bets.AddAsync(bet);
        }

        public async Task<Bet> GetBet(int userId, int gameId)
        {
            return await Context.Bets
                .AsNoTracking()
                .SingleOrDefaultAsync(bet => bet.UserId == userId && bet.GameId == gameId);
        }

        public void UpdateBet(Bet bet)
        {
            Context.Bets.Update(bet);
        }

        public async Task UpsertBet(Bet bet)
        {
            if (bet.BetId == default)
            {
                await AddBet(bet);
            }
            else
            {
                UpdateBet(bet); 
            }
        }
    }
}
