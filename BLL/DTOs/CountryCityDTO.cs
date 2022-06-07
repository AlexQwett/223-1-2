namespace BLL.DTOs
{
    public class CountryCityDTO
    {
        public int CountryCityId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual CityDTO City { get; set; } = null!;
        public virtual CountryDTO Country { get; set; } = null!;
    }
}
