using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryRepository;

        public CategoryController(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с категориями";
            IEnumerable<Category> categories = _categoryRepository.AllCategories;
            return View(categories);
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult Add(string name, string description)
        {
            Category newCategory = new Category()
            {
                Name = name,
                Description = description
            };

            _categoryRepository.Add(newCategory);
            return Redirect("/Category/List");
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            Category category = _categoryRepository.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public RedirectResult Update(int id, string name, string description)
        {
            Category category = new Category()
            {
                Id = id,
                Name = name,
                Description = description
            };

            _categoryRepository.Update(category);
            return Redirect("/Category/List");
        }
        [HttpGet]
        public RedirectResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return Redirect("/Category/List");
        }
    }
}