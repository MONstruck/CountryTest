using CountryTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetActivities();
        Task<Activity> GetActivitiesById(int ActivityId);
        Task<bool> DeleteActivity(int ActivityId);
        Task UpdateActivity(Activity Activity);
        Task AddActivity(Activity Activity, string countryISOCode);
        Task<List<Activity>> GetActivitiesByISO(string ISO);
        Task<Activity> GetActivitiesByUniqCode(string uniqCode);
        Task<Activity> GetActivitiesByUniqCodeAndISO(string uniqCode, string ISO);
    }
}
