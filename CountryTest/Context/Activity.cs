using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryTest.Context
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int ActivityCategory { get; set; }
        public string UniqId { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
