using Microsoft.AspNetCore.Mvc;
using Shop.Data.Classes;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;

namespace Shop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IItem _iAllItems;
        private ICategory _iAllCategories;
        private VMItems _vmItems = new VMItems();
        public ItemController(IItem iAllItems, ICategory iAllCategories, IWebHostEnvironment hostingEnvironment)
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
            string fileName = "";

            if (files != null && files.Length > 0)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(stream);
                }
            }

            Item newItems = new Item();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = fileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Category() { Id = idCategory };

            int id = _iAllItems.Add(newItems);

            return Redirect("/Item/List");
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            Item item = _iAllItems.GetItem(id);
            IEnumerable<Category> categories = _iAllCategories.AllCategories;

            var viewModel = new VMUpdateItem
            {
                Item = item,
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public RedirectResult Update(int id, string name, string description, float price, int idCategory)
        {
            Item existingItem = _iAllItems.GetItem(id);

            if (existingItem != null)
            {
                existingItem.Name = name;
                existingItem.Description = description;
                existingItem.Price = Convert.ToInt32(price);
                existingItem.Category = new Category() { Id = idCategory };

                _iAllItems.Update(existingItem);
            }

            return Redirect("/Item/List");
        }

        [HttpGet]
        public RedirectResult Delete(int id)
        {
            _iAllItems.Delete(id);
            return Redirect("/Item/List");
        }
        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1)
            {
                Startup.BasketItem.Add(new ItemsBasket(1, _iAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }

            return Json(Startup.BasketItem);
        }
        public ActionResult BasketCount(int idItem = -1, int count = -1)
        {
            if (idItem != -1)
            {
                if (count == 0)
                {
                    Startup.BasketItem.Remove(Startup.BasketItem.Find(x => x.Id == idItem));
                }
                else
                {
                    Startup.BasketItem.Find(x => x.Id == idItem).Count = count;
                }
            }

            return Json(Startup.BasketItem);
        }

    }
}
