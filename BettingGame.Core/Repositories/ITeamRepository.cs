using BettingGame.Core.Models.Domain;
using System.Threading.Tasks;

namespace BettingGame.Core.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetTeam(int teamId);
    }
}
