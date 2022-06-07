using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Tour
    {
        public Tour()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TourId { get; set; }
        public int HotelId { get; set; }
        public decimal? Price { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
