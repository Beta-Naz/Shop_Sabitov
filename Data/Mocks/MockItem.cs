using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
    public class MockItem : IItem
    {
        private ICategory _category = new MockCaregory();
        public IEnumerable<Item> AllItems
        {
            get
            {
                return new List<Item>()
                {
                    new Item
                    {
                        Id = 0,
                        Name = "Куб черный",
                        Description = "Черный",
                        Img = "/img/dark_cube.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 1,
                        Name = "Куб красный",
                        Description = "Красный",
                        Img = "/img/red_cube.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "Куб желтый",
                        Description = "Желтый",
                        Img = "/img/yellow_cube.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "Куб зеленный",
                        Description = "Зеленный",
                        Img = "/img/green_cube.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "Сфера зеленная",
                        Description = "Зеленный",
                        Img = "/img/violet_sphere.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "Сфера фиолетовая",
                        Description = "Кольмисильма",
                        Img = "/img/green_sphere.jpg",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    },
                };
            }
        }

        public int Add(Item item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> FindItems(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
