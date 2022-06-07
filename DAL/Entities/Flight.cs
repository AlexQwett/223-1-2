using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Flight
    {
        public int FlightId { get; set; }
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }

        public virtual City CityFrom { get; set; } = null!;
        public virtual City CityTo { get; set; } = null!;
    }
}
