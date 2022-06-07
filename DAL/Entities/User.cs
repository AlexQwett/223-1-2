using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
