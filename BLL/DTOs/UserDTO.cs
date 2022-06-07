﻿namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<BookingDTO> Bookings { get; set; }
    }
}
