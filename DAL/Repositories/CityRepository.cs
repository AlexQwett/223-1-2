using DAL.Entities;
using DAL.Exceptions;

namespace DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {

        private readonly TravelAgencyContext _context;
        public CityRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(City entity)
        {
            _context.Cities.Attach(entity);
        }

        public void Delete(int id)
        {
            var city = _context.Cities.Find(id);
            if (city is null)
                throw new NotFoundException();
            _context.Cities.Remove(city);
        }

        public City? Get(int id)
        {
            return _context.Cities.FirstOrDefault(x => x.CityId == id);
        }

        public ICollection<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public void Update(City entity)
        {
            _context.Cities.Update(entity);
        }
    }
}
