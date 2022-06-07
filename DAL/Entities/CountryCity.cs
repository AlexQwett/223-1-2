using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CountryCity
    {
        public int CountryCityId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
    }
}
