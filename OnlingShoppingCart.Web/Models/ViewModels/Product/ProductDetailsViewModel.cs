using OnlineShoppingCart.Data.Models;
using OnlingShoppingCart.Web.Models.ViewModels.Category;

namespace OnlingShoppingCart.Web.Models.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        public List<CategoryViewModel> CategoryName { get; set; }
    }
}
