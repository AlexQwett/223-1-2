using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int HotelId { get; set; }
        public string? HotelTitle { get; set; }
        public byte? Stars { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
