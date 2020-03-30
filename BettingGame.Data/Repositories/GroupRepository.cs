using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class GroupRepository : Repository<BettingGameContext>, IGroupRepository
    {
        public GroupRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task CreateGroup(Group group)
        {
            await Context.Groups.AddAsync(group);
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await Context.Groups
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
