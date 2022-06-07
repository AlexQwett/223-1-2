using DAL.Entities;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private readonly TravelAgencyContext _context;
        public CountryRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(Country entity)
        {
            _context.Countries.Attach(entity);
        }

        public void Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country is null)
                throw new NotFoundException();
            _context.Countries.Remove(country);
        }

        public Country? Get(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.CountryId == id);
        }

        public ICollection<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public void Update(Country entity)
        {
            _context.Countries.Update(entity);
        }
    }
}
