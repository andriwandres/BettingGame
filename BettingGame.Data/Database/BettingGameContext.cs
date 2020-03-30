using BettingGame.Core.Models.Domain;
using BettingGame.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BettingGame.Data.Database
{
    public class BettingGameContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupInviteCode> GroupInviteCodes { get; set; }
        public DbSet<GroupInviteCodeUsage> GroupInviteCodeUsages { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public DbSet<PasswordResetCode> PasswordResetCodes { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRanking> UserRankings { get; set; }

        public BettingGameContext(DbContextOptions<BettingGameContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new BetConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameResultConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupInviteCodeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupInviteCodeUsageConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordResetCodeConfiguration());
            modelBuilder.ApplyConfiguration(new PhaseConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRankingConfiguration());
        }
    }
}
