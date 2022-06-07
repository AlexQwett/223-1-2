using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = null!;
    }
}
