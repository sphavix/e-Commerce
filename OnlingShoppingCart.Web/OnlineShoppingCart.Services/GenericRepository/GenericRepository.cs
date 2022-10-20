using Microsoft.EntityFrameworkCore;
using OnlingShoppingCart.Services.Database;
using OnlingShoppingCart.Web.OnlineShoppingCart.Data.Entities;
using OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure;

namespace OnlingShoppingCart.Web.OnlineShoppingCart.Services.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
