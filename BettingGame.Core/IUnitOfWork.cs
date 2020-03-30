using BettingGame.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BettingGame.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBetRepository BetRepository { get; }
        ICountryRepository CountryRepository { get; }
        IGameRepository GameRepository { get; }
        IGameResultRepository GameResultRepository { get; }
        IGroupRepository GroupRepository { get; }
        IGroupInviteCodeRepository GroupInviteCodeRepository { get; }
        IGroupInviteCodeUsageRepository GroupInviteCodeUsageRepository { get; }
        IGroupMembershipRepository GroupMembershipRepository { get; }
        IPasswordResetCodeRepository PasswordResetRepository { get; }
        IPhaseRepository PhaseRepository { get; }
        ITeamRepository TeamRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRankingRepository UserRankingRepository { get; }
        Task<int> Commit();
    }
}
