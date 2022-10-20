using OnlingShoppingCart.Web.OnlineShoppingCart.Data.Entities;

namespace OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
