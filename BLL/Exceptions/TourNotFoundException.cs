using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public sealed class TourNotFoundException : Exception
    {
        public TourNotFoundException()
            : base("Tour not found")
        {
        }
    }
}
