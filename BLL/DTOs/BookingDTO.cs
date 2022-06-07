namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }

        public virtual TourDTO Tour { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
