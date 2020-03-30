using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IGroupInviteCodeUsageRepository
    {
        Task UseInviteCode(GroupInviteCodeUsage usage);
    }
}
