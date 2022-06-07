using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }

        public virtual Tour Tour { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
