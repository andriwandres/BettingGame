using System;
using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class Phase
    {
        public int PhaseId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
