using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGroupInviteCodeRepository
    {
        Task CreateInviteCode(GroupInviteCode inviteCode);
    }
}
