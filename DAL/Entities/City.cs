using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class City
    {
        public City()
        {
            FlightCityFroms = new HashSet<Flight>();
            FlightCityTos = new HashSet<Flight>();
            Hotels = new HashSet<Hotel>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }

        public virtual ICollection<Flight> FlightCityFroms { get; set; }
        public virtual ICollection<Flight> FlightCityTos { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
