using BettingGame.Core.Models.Domain;
using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Data.Repositories
{
    public class CountryRepository : Repository<BettingGameContext>, ICountryRepository
    {
        public CountryRepository(BettingGameContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await Context.Countries
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
