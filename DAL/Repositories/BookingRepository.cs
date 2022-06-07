using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly TravelAgencyContext _context;
        public BookingRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(Booking entity)
        {
            var tour = _context.Tours.FirstOrDefault(x => x.TourId == entity.TourId);
            var user = _context.Users.FirstOrDefault(x => x.UserId == entity.UserId);

            if (tour is null || user is null)
                throw new NotFoundException();
            _context.Bookings.Attach(new Booking
            {
                TourId = tour.TourId,
                Tour = tour,
                UserId = user.UserId,
                User = user,
            });
        }

        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking is null)
                throw new NotFoundException();
            _context.Bookings.Remove(booking);
        }

        public Booking? Get(int id)
        {
            return _context.Bookings.FirstOrDefault(x => x.BookingId == id);
        }

        public ICollection<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public void Update(Booking entity)
        {
            /*var tour = _context.Tours.AsNoTracking().FirstOrDefault(x => x.TourId == entity.TourId);
            var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.UserId == entity.UserId);

            if (tour is null || user is null)
                throw new NotFoundException();*/
            _context.Bookings.Update(entity);
        }
    }
}
