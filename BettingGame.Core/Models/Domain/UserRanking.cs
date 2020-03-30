namespace BettingGame.Core.Models.Domain
{
    public class UserRanking
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public int DifferenceToLastRanking { get; set; }

        public User User { get; set; }
    }
}
