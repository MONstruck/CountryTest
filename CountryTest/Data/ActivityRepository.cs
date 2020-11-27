using CountryTest.Context;
using CountryTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Data
{
    public class ActivityRepository : IActivityRepository
    {
        public async Task<List<Activity>> GetActivities()
        {
            using (var db = new CountryContext())
            {
                return await db.Activity.ToListAsync();
            }
        }
        public async Task<List<Activity>> GetActivitiesByISO(string ISO)
        {
            using (var db = new CountryContext())
            {
                var countryId = db.Country.FirstOrDefaultAsync(_ => _.CountryISOCode == ISO).Result.CountryId;
                return await db.Activity.Where(_ => _.CountryId== countryId).ToListAsync();
            }
        }
        public async Task<Activity> GetActivitiesByUniqCode(string uniqCode)
        {
            using (var db = new CountryContext())
            {
                return await db.Activity.FirstOrDefaultAsync(_ => _.UniqId == uniqCode);
            }
        }
        public async Task<Activity> GetActivitiesByUniqCodeAndISO(string uniqCode, string ISO)
        {
            using (var db = new CountryContext())
            {
                var countryId = db.Country.FirstOrDefaultAsync(_ => _.CountryISOCode == ISO).Result.CountryId;
                return await db.Activity.FirstOrDefaultAsync(_ => _.CountryId == countryId && _.UniqId == uniqCode);
            }
        }
        public async Task<Activity> GetActivitiesById(int ActivityId)
        {
            using (var db = new CountryContext())
            {
                return await db.Activity.FirstOrDefaultAsync(_ => _.ActivityId == ActivityId);
            }
        }
        public async Task<bool> DeleteActivity(int ActivityId)
        {
            using (var db = new CountryContext())
            {
                var ActivityForDelete = await db.Activity.FirstOrDefaultAsync(_ => _.ActivityId == ActivityId);
                if(ActivityForDelete == null)
                {
                    return false;
                }

                db.Activity.Remove(ActivityForDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
        public async Task UpdateActivity(Activity Activity)
        {
            using (var db = new CountryContext())
            {
                db.Activity.Update(Activity);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddActivity(Activity Activity, string countryISOCode)
        {
            using (var db = new CountryContext())
            {
                Activity.UniqId = GenereteUniqId(countryISOCode, Activity.ActivityName);
                await db.Activity.AddAsync(Activity);
                await db.SaveChangesAsync();
            }
        }

        private static string GenereteUniqId(string ISOCode, string activityName)
        {
            string generat = activityName.Substring(activityName.Length - 1) + activityName.Substring(0);
            return string.Format("{0}{1}", ISOCode, activityName);
        }
    }
}
