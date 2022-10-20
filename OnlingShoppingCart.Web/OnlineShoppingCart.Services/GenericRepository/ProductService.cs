using Microsoft.EntityFrameworkCore;
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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _context;

        public ProductService(IGenericRepository<Product> context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _context.GetById(id);
        }

        public IEnumerable<Category> GetProductCategory(int id)
        {
            var product = GetProductById(id);
            var productCategory = product.Categories.Select(x => x.Category);
            return productCategory;
        }
        public void AddProduct(Product product, List<int> categories)
        {
            foreach (var item in categories)
            {
                product.Categories.Add(new ProductCategory()
                {
                    Product = product,
                    CategoryId = item
                });
            }
            _context.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
        }
        public void DeleteProduct(Product product)
        {
            _context.Delete(product);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
