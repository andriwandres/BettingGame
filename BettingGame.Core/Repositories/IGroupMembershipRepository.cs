using BettingGame.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGroupMembershipRepository
    {
        Task<IEnumerable<GroupMembership>> GetMembershipsByGroup(int groupId);
        Task<IEnumerable<GroupMembership>> GetMembershipsByUser(int userId);
        Task AddMembership(GroupMembership membership);
    }
}
