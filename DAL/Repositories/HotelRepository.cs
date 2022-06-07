using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly TravelAgencyContext _context;
        public HotelRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(Hotel entity)
        {
            var city = _context.Cities.FirstOrDefault(x => x.CityId == entity.City.CityId);
            if (city is null)
                throw new NotFoundException();
            var hotel = new Hotel
            {
                CityId = city.CityId,
                City = city,
                Stars = entity.Stars,
                HotelTitle = entity.HotelTitle
            };

            _context.Entry(entity).State = EntityState.Detached;

            _context.Hotels.Attach(hotel);
        }

        public void Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel is null)
                throw new NotFoundException();
            _context.Hotels.Remove(hotel);
        }

        public Hotel? Get(int id)
        {
            return _context.Hotels.FirstOrDefault(x => x.HotelId == id);
        }

        public ICollection<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public void Update(Hotel entity)
        {
            /*var city = _context.Cities.AsNoTracking().FirstOrDefault(x => x.CityId == entity.CityId);
            if (city is null)
                throw new NotFoundException();*/
            _context.Hotels.Update(entity);
        }
    }
}
