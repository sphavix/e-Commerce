using OnlingShoppingCart.Web.OnlineShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Data.Models
{
    public class ProductCategory:BaseEntity
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
