using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public Country Country { get; set; }
        public ICollection<Game> HomeGames { get; set; }
        public ICollection<Game> GuestGames { get; set; }
    }
}
