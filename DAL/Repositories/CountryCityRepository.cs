using DAL.Entities;
using DAL.Exceptions;

namespace DAL.Repositories
{
    public class CountryCityRepository : IRepository<CountryCity>
    {
        private readonly TravelAgencyContext _context;
        public CountryCityRepository(TravelAgencyContext context)
        {
            _context = context;
        }
        public void Add(CountryCity entity)
        {
            _context.CountryCities.Attach(entity);
        }

        public void Delete(int id)
        {
            var countryCity = _context.CountryCities.Find(id);
            if (countryCity is null)
                throw new NotFoundException();
            _context.CountryCities.Remove(countryCity);
        }

        public CountryCity? Get(int id)
        {
            return _context.CountryCities.FirstOrDefault(x => x.CountryCityId == id);
        }

        public ICollection<CountryCity> GetAll()
        {
            return _context.CountryCities.ToList();
        }

        public void Update(CountryCity entity)
        {
            _context.CountryCities.Update(entity);
        }
    }
}
