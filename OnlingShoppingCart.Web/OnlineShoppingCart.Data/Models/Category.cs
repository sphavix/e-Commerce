using OnlingShoppingCart.Web.OnlineShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Data.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductCategory> Products { get; set; } = new List<ProductCategory>(); 
    }
}
