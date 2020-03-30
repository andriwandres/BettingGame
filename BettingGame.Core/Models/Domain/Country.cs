using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public byte[] FlagImage { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
