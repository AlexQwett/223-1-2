using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly TravelAgencyContext _context;
        public UserRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Attach(entity);
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null)
                throw new NotFoundException();
            _context.Users.Remove(user);
        }

        public User? Get(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User entity)
        {
            /*var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.UserId == entity.UserId);
            if (user is null)
                throw new NotFoundException();*/
            _context.Users.Update(entity);
        }
    }
}
