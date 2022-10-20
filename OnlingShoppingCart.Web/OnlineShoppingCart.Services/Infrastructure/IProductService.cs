using OnlineShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Category> GetProductCategory(int id);
        Product GetProductById(int id);
        void AddProduct(Product product, List<int> categories);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void Save();
    }
}
