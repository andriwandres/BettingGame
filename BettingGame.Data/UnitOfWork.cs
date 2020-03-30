using BettingGame.Core;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using BettingGame.Data.Repositories;
using System.Threading.Tasks;

namespace BettingGame.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BettingGameContext _context;

        private BetRepository _betRepository;
        private CountryRepository _countryRepository;
        private GameRepository _gameRepository;
        private GameResultRepository _gameResultRepository;
        private GroupRepository _groupRepository;
        private GroupInviteCodeRepository _groupInviteCodeRepository;
        private GroupInviteCodeUsageRepository _groupInviteCodeUsageRepository;
        private GroupMembershipRepository _groupMembershipRepository;
        private PasswordResetCodeRepository _passwordResetCodeRepository;
        private PhaseRepository _phaseRepository;
        private TeamRepository _teamRepository;
        private UserRankingRepository _userRankingRepository;
        private UserRepository _userRepository;

        public UnitOfWork(BettingGameContext context)
        {
            _context = context;
        }

        public IBetRepository BetRepository =>
            _betRepository = _betRepository ?? new BetRepository(_context);

        public ICountryRepository CountryRepository =>
            _countryRepository = _countryRepository ?? new CountryRepository(_context);

        public IGameRepository GameRepository =>
            _gameRepository = _gameRepository ?? new GameRepository(_context);

        public IGameResultRepository GameResultRepository =>
            _gameResultRepository = _gameResultRepository ?? new GameResultRepository(_context);

        public IGroupRepository GroupRepository =>
            _groupRepository = _groupRepository ?? new GroupRepository(_context);

        public IGroupInviteCodeRepository GroupInviteCodeRepository =>
            _groupInviteCodeRepository = _groupInviteCodeRepository ?? new GroupInviteCodeRepository(_context);

        public IGroupInviteCodeUsageRepository GroupInviteCodeUsageRepository =>
            _groupInviteCodeUsageRepository = _groupInviteCodeUsageRepository ?? new GroupInviteCodeUsageRepository(_context);

        public IGroupMembershipRepository GroupMembershipRepository =>
            _groupMembershipRepository = _groupMembershipRepository ?? new GroupMembershipRepository(_context);

        public IPasswordResetCodeRepository PasswordResetRepository =>
            _passwordResetCodeRepository = _passwordResetCodeRepository ?? new PasswordResetCodeRepository(_context);

        public IPhaseRepository PhaseRepository =>
            _phaseRepository = _phaseRepository ?? new PhaseRepository(_context);

        public ITeamRepository TeamRepository =>
            _teamRepository = _teamRepository ?? new TeamRepository(_context);

        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository(_context);

        public IUserRankingRepository UserRankingRepository =>
            _userRankingRepository = _userRankingRepository ?? new UserRankingRepository(_context);


        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
