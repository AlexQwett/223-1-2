namespace BLL.DTOs
{
    public class HotelDTO
    {
        public int HotelId { get; set; }
        public string? HotelTitle { get; set; }
        public byte? Stars { get; set; }
        public int CityId { get; set; }
        public CityDTO City { get; set; } = null!;

    }
}
