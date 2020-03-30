using System;

namespace BettingGame.Core.Models.Domain
{
    public class Bet
    {
        public int BetId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }
        public DateTime LastModified { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }
    }
}
