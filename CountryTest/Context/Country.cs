using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Context
{
    public class Country
    {
        public Country()
        {
            Activity = new HashSet<Activity>();
        }
        public int CountryId { get; set; }
        public string CountryISOCode { get; set; }
        public string CityName { get; set; }

        public ICollection<Activity> Activity { get; set; }

    }
}
