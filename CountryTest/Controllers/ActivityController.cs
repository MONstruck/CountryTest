using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryTest.Context;
using CountryTest.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICountryRepository _countryRepository;

        public ActivityController(IActivityRepository activityRepository,
            ICountryRepository countryRepository)
        {
            _activityRepository = activityRepository;
            _countryRepository = countryRepository;
        }
        // GET: api/<CountryController>
        
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> Get()
        {
            var records = await _activityRepository.GetActivities();
            return records;
        }

  
       
        // GET api/<CountryController>/5
        [HttpGet("{iso}")]
        public async Task<ActionResult<List<Activity>>> Get(string iso)
        {
            var records = await _activityRepository.GetActivitiesByISO(iso);
            return records;
        }
        
        // GET api/<CountryController>/5
        [HttpGet("{iso},{id}")]
        public async Task<ActionResult<Activity>> Get(string iso, string uniq)
        {
            var record = await _activityRepository.GetActivitiesByUniqCodeAndISO(uniq,iso);
            return record;
        }
        
        // POST api/<CountryController>
        [HttpPost("{iso}")]
        public async Task<ActionResult> Post(string iso, Activity activity)
        {
            await _activityRepository.AddActivity(activity,iso);
            return NoContent();

        }
        
        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return BadRequest();
            }
            await _activityRepository.UpdateActivity(activity);
            return NoContent();
        }
        
        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _activityRepository.DeleteActivity(id))
                return NoContent();
            else
            {
                return NotFound();
            }
        }
    }
}
