using CountryTest.Context;
using CountryTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Data
{
    public class CountryRepository : ICountryRepository
    {
        public async Task<List<Country>> GetCountries()
        {
            using (var db = new CountryContext())
            {
                return await db.Country.ToListAsync();
            }
        }
        public async Task<Country> GetCountriesById(int countryId)
        {
            using (var db = new CountryContext())
            {
                return await db.Country.FirstOrDefaultAsync(_ => _.CountryId == countryId);
            }
        }
        public async Task<bool> DeleteCountry(int countryId)
        {
            using (var db = new CountryContext())
            {
                var countryForDelete = await db.Country.FirstOrDefaultAsync(_ => _.CountryId == countryId);
                if (countryForDelete == null)
                {
                    return false;
                }
                
                db.Country.Remove(countryForDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
        public async Task UpdateCountry(Country country)
        {
            using (var db = new CountryContext())
            {
                db.Country.Update(country);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddCountry(Country country)
        {
            using (var db = new CountryContext())
            {
                await db.Country.AddAsync(country);
                await db.SaveChangesAsync();
            }
        }

    }
}
