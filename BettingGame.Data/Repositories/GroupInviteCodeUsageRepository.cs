using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GroupInviteCodeUsageRepository : Repository<BettingGameContext>, IGroupInviteCodeUsageRepository
    {
        public GroupInviteCodeUsageRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task UseInviteCode(GroupInviteCodeUsage usage)
        {
            await Context.GroupInviteCodeUsages.AddAsync(usage);
        }
    }
}
