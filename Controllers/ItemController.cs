using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
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
        public ViewResult List(int id = -1)
        {
            ViewBag.Title = "Страница с предметами";
            _vmItems.Items = _iAllItems.AllItems;
            _vmItems.Categorys = _iAllCategories.AllCategories;
            _vmItems.SelectCategory = id;
            return View(_vmItems);
        }
    }
}
