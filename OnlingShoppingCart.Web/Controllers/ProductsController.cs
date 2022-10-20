using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShoppingCart.Data.Models;
using OnlingShoppingCart.Web.Helpers;
using OnlingShoppingCart.Web.Models.ViewModels.Category;
using OnlingShoppingCart.Web.Models.ViewModels.Product;
using OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure;

namespace OnlingShoppingCart.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService service, IMapper mapper, ICategoryService categoryService, 
            IWebHostEnvironment environment)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _service.GetProducts();
            var mappedProducts = _mapper.Map<List<ProductViewModel>>(products);
            return View(mappedProducts);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var product = _service.GetProductById(id);
            var mappedProduct = _mapper.Map<ProductDetailsViewModel>(product);
            return View(mappedProduct);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductViewModel productModel = new CreateProductViewModel();
            productModel.Categories = _categoryService.GetCategories().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(productModel);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {

            FileUpload uploadFile = new FileUpload(_environment);
            var selectedCategory = model.Categories.Where(x => x.Selected).Select(x => x.Value).Select(int.Parse).ToList();
            string ImageFile = uploadFile.UploadFile(model.ProductImage);
            var product = new PostedProductViewModel
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ProductImage = ImageFile
            };
            var mappedProduct = _mapper.Map<Product>(product);
            _service.AddProduct(mappedProduct, selectedCategory);
            _service.Save();
            return RedirectToAction(nameof(Index), "Products");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _service.GetProductById(id);
            var mappedProduct = _mapper.Map<UpdateProductViewModel>(product);
            return View(mappedProduct);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel model)
        {
            var mappedProduct = _mapper.Map<Product>(model);
            _service.UpdateProduct(mappedProduct);
            _service.Save();
            return RedirectToAction(nameof(Index), "Products");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = _service.GetProductById(id);
            var mappedProduct = _mapper.Map<DeleteProductViewModel>(product);
            return View(mappedProduct);
        }

        [HttpPost]
        public IActionResult DeleteProduct(DeleteProductViewModel model)
        {
            var mappedProduct = _mapper.Map<Product>(model);
            _service.DeleteProduct(mappedProduct);
            _service.Save();
            return RedirectToAction(nameof(Index), "Products");
        }

    }
}
