using BettingGame.Core;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingGame.Service.Domain
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _unitOfWork.CountryRepository.GetCountries();
        }
    }
}
