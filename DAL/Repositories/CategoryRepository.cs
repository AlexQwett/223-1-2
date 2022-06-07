using DAL.Entities;
using DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly TravelAgencyContext _context;
        public CategoryRepository(TravelAgencyContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Attach(entity);
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
                throw new NotFoundException();
            _context.Categories.Remove(category);
        }

        public Category? Get(int id)
        {
            return _context.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == id);
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
