namespace BLL.DTOs
{
    public class TourDTO
    {
        public int TourId { get; set; }
        public int HotelId { get; set; }
        public HotelDTO Hotel { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
