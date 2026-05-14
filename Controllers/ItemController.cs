using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;


namespace Shop.Controllers
{
    public class ItemController : Controller
    {
        private IItem IAllItems;
        private ICategory IAllCategories;
        public ItemController(IItem iAllItems, ICategory iAllCategories)
        {
            IAllItems = iAllItems;
            IAllCategories = iAllCategories;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";
            var cars = IAllItems.AllItems;
            return View(cars);
        }
    }
}
