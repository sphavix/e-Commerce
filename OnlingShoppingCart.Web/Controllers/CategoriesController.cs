using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Data.Models;
using OnlingShoppingCart.Web.Models.ViewModels.Category;
using OnlingShoppingCart.Web.OnlineShoppingCart.Services.Infrastructure;

namespace OnlingShoppingCart.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _service.GetCategories();
            var mappedCategories = _mapper.Map<List<CategoryViewModel>>(categories);
            return View(mappedCategories);
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var category = _service.GetCategoryById(id);
            var mappedCategory = _mapper.Map<CategoryDetailsViewModel>(category);
            return View(mappedCategory);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {
            var mappedCategory = _mapper.Map<Category>(model);
            _service.AddCategory(mappedCategory);
            _service.Save();
            return RedirectToAction(nameof(Index), "Categories");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _service.GetCategoryById(id);
            var mappedCategory = _mapper.Map<UpdateCategoryViewModel>(category);
            return View(mappedCategory);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryViewModel model)
        {
            var mappedCategory = _mapper.Map<Category>(model);
            _service.UpdateCategory(mappedCategory);
            _service.Save();
            return RedirectToAction(nameof(Index), "Categories");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var category = _service.GetCategoryById(id);
            var mappedCategory = _mapper.Map<DeleteCategoryViewModel>(category);
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCategory(DeleteCategoryViewModel model)
        {
            var mappedCategory = _mapper.Map<Category>(model);
            _service.DeleteCategory(mappedCategory);
            _service.Save();
            return RedirectToAction(nameof(Index), "Categories");
        }
    }
}
