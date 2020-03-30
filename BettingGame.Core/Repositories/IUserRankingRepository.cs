using BettingGame.Core.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface IUserRankingRepository
    {
        Task<IEnumerable<UserRanking>> GetRankings();
        Task<UserRanking> GetRanking(int userId);
        Task UpsertRanking(UserRanking ranking);
        Task AddRanking(UserRanking ranking);
        void UpdateRanking(UserRanking ranking);
    }
}
