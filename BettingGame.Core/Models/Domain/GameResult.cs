using System;

namespace BettingGame.Core.Models.Domain
{
    public class GameResult
    {
        public int GameId { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }
        public DateTime CreatedAt { get; set; }

        public Game Game { get; set; }
    }
}
