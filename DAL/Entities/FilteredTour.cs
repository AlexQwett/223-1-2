using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class FilteredTour
    {
        public int FilteredTourId { get; set; }
        public int CategoryId { get; set; }
        public int TourId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
