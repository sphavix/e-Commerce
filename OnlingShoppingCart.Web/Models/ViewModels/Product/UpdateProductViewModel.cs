using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlingShoppingCart.Web.Models.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
