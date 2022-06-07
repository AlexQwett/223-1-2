using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TourRepository : IRepository<Tour>
    {
        private readonly TravelAgencyContext _context;
        public TourRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(Tour entity)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.HotelId == entity.Hotel.HotelId);
            if (hotel is null)
                throw new NotFoundException();
            var tour = new Tour
            {
                HotelId = entity.HotelId,
                Hotel = hotel,
                Price = entity.Price
            };
            _context.Tours.Attach(tour);
        }

        public void Delete(int id)
        {
            var tour = _context.Tours.Find(id);
            if (tour is null)
                throw new NotFoundException();
            _context.Tours.Remove(tour);
        }

        public Tour? Get(int id)
        {
            return _context.Tours.FirstOrDefault(x => x.TourId == id);
        }

        public ICollection<Tour> GetAll()
        {
            return _context.Tours.ToList();
        }

        public void Update(Tour entity)
        {
           /* var hotel = _context.Hotels.AsNoTracking().FirstOrDefault(x => x.HotelId == entity.HotelId);
            if (hotel is null)
                throw new NotFoundException();*/
            _context.Tours.Update(entity);
        }
    }
}
