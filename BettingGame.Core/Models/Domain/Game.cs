using System;
using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class Game
    {
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int PhaseId { get; set; }
        public DateTime Date { get; set; }
        public DateTime BetsDue { get; set; }

        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public Phase Phase { get; set; }
        public GameResult Result { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
