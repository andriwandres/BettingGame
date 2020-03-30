using BettingGame.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroups();
        Task CreateGroup(Group group);
    }
}
