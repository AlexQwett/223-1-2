

using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FilteredTourRepository : IRepository<FilteredTour>
    {
        private readonly TravelAgencyContext _context;
        public FilteredTourRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(FilteredTour entity)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == entity.Category.CategoryId);
            var tour = _context.Tours.FirstOrDefault(x => x.TourId == entity.Tour.TourId);
            if (category is null || tour is null)
                throw new NotFoundException();
            _context.FilteredTours.Attach(new FilteredTour
            {
                CategoryId = category.CategoryId,
                Category = category,
                TourId = tour.TourId,
                Tour = tour
            });
        }

        public void Delete(int id)
        {
            var filteredTour = _context.FilteredTours.Find(id);
            if (filteredTour is null)
                throw new NotFoundException();
            _context.FilteredTours.Remove(filteredTour);
        }

        public FilteredTour? Get(int id)
        {
            return _context.FilteredTours.FirstOrDefault(x => x.FilteredTourId == id); 
        }

        public ICollection<FilteredTour> GetAll()
        {
            return _context.FilteredTours.ToList();
        }

        public void Update(FilteredTour entity)
        {
            /*var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == entity.CategoryId);
            var tour = _context.Tours.AsNoTracking().FirstOrDefault(x => x.TourId == entity.TourId);
            if (category is null || tour is null)
                throw new NotFoundException();*/
            _context.FilteredTours.Update(entity);
        }
    }
}
   