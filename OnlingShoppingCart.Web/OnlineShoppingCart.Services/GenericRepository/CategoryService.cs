using OnlineShoppingCart.Data.Models;
using OnlingShoppingCart.Services.Database;
using OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlingShoppingCart.Web.OnlineShoppingCart.Services.GenericRepository
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _context;

        public CategoryService(IGenericRepository<Category> context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _context.GetById(id);
        }
        public void AddCategory(Category category)
        {
            _context.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
        }
        public void DeleteCategory(Category category)
        {
            _context.Delete(category);
        }

        public void Save()
        {
            _context.Save();
        }


    }
}
