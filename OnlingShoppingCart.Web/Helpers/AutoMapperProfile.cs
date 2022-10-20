using AutoMapper;
using OnlineShoppingCart.Data.Models;
using OnlingShoppingCart.Web.Models.ViewModels.Category;
using OnlingShoppingCart.Web.Models.ViewModels.Product;

namespace OnlingShoppingCart.Web.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //Add a source class to map to a view model.
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap(); //reverse map for Get and Post methods.
            CreateMap<CreateCategoryViewModel, Category>().ReverseMap(); //reverse map for Get and Post methods.
            CreateMap<Category, DeleteCategoryViewModel>().ReverseMap(); //reverse map for Get and Post methods.

            CreateMap<Product, ProductViewModel>();
            CreateMap<CreateProductViewModel, Product>().ReverseMap();
            CreateMap<Product, UpdateProductViewModel>().ReverseMap();

            CreateMap<Product, DeleteProductViewModel>().ReverseMap();
            CreateMap<PostedProductViewModel, Product>();
            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Categories
                .Select(x => x.Category).ToList()));
        }
    }
}
