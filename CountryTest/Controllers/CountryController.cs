using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryTest.Context;
using CountryTest.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CountryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        // GET: api/<CountryController>
        
        [HttpGet]
        public async Task<ActionResult<List<Country>>> Get()
        {
            var records = await _countryRepository.GetCountries();
            return records;
        }
        [Route("{id:int}")]
        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            var record = await _countryRepository.GetCountriesById(id);
            return record;
        }
        
        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            await _countryRepository.AddCountry(country);
            return NoContent();

        }
        
        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Country Country)
        {
            if (id != Country.CountryId)
            {
                return BadRequest();
            }
            await _countryRepository.UpdateCountry(Country);
            return NoContent();
        }
       
        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _countryRepository.DeleteCountry(id))
                return NoContent();
            else
            {
                return NotFound();
            }
        }
    }
}
