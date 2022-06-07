namespace BLL.DTOs
{
    public class FilteredTourDTO
    {
        public int FilteredTourId { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }

        public virtual CategoryDTO Category { get; set; } = null!;
        public virtual TourDTO Tour { get; set; } = null!;
    }
}
