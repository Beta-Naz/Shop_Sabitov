using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;


namespace Shop.Controllers
{
    public class ItemController : Controller
    {
        private IItem _iAllItems;
        private ICategory _iAllCategories;
        private VMItems _vmItems = new VMItems();
        public ItemController(IItem iAllItems, ICategory iAllCategories)
        {
            _iAllItems = iAllItems;
            _iAllCategories = iAllCategories;
        }
        public ViewResult List(int id = -1, string sortOrder = "", string searchString = "")
        {
            ViewBag.Title = "Страница с предметами";
            IEnumerable<Item> items;
            if (!string.IsNullOrEmpty(searchString))
            {
                items = _iAllItems.FindItems(searchString);
            }
            else
            {
                items = _iAllItems.AllItems;
            }
            switch (sortOrder)
            {
                case "price_desc":
                    items = items.OrderByDescending(x => x.Price);
                    break;
                case "price_asc":
                    items = items.OrderBy(x => x.Price);
                    break;
                default:
                    items = items.OrderBy(x => x.Id);
                    break;
            }
            _vmItems.SortOrder = sortOrder;
            _vmItems.Items = items;
            _vmItems.Categorys = _iAllCategories.AllCategories;
            _vmItems.SelectCategory = id;

            return View(_vmItems);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Category> categories = _iAllCategories.AllCategories;
            return View(categories);
        }
    }
}
