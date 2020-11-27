using CountryTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountriesById(int countryId);
        Task<bool> DeleteCountry(int countryId);
        Task UpdateCountry(Country country);
        Task AddCountry(Country country);
    }
}
