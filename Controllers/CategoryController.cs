using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory IAllCategories;
        public CategoryController(ICategory iAllCategories)
        {
            IAllCategories = iAllCategories;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница категории";
            var cars = IAllCategories.AllCategories;
            return View(cars);
        }
    }
}
