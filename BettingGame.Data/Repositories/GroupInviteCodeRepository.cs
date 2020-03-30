using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GroupInviteCodeRepository : Repository<BettingGameContext>, IGroupInviteCodeRepository
    {
        public GroupInviteCodeRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task CreateInviteCode(GroupInviteCode inviteCode)
        {
            await Context.GroupInviteCodes.AddAsync(inviteCode);
        }
    }
}
