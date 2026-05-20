using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Shop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IItem _iAllItems;
        private ICategory _iAllCategories;
        private VMItems _vmItems = new VMItems();
        public ItemController(IItem iAllItems, ICategory iAllCategories, IHostingEnvironment hostingEnvironment)
        {
            _iAllItems = iAllItems;
            _iAllCategories = iAllCategories;
            _hostingEnvironment = hostingEnvironment;
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
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Item newItems = new Item();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Category() { Id = idCategory };

            int id = _iAllItems.Add(newItems);

            return Redirect("/Items/Update?id=" + id);
        }
    }
}
