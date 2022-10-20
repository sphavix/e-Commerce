using OnlingShoppingCart.Web.OnlineShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Data.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        public ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
    }
}
