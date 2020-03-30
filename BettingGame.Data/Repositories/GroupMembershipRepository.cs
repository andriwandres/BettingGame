using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GroupMembershipRepository : Repository<BettingGameContext>, IGroupMembershipRepository
    {
        public GroupMembershipRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task AddMembership(GroupMembership membership)
        {
            await Context.GroupMemberships.AddAsync(membership);
        }

        public async Task<IEnumerable<GroupMembership>> GetMembershipsByGroup(int groupId)
        {
            return await Context.GroupMemberships
                .AsNoTracking()
                .Where(membership => membership.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupMembership>> GetMembershipsByUser(int userId)
        {
            return await Context.GroupMemberships
                .AsNoTracking()
                .Where(membership => membership.UserId == userId)
                .ToListAsync();
        }
    }
}
