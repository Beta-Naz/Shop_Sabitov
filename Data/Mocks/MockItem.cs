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
                        Img = "",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 1,
                        Name = "Куб красный",
                        Description = "Красный",
                        Img = "",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "Куб желтый",
                        Description = "Желтый",
                        Img = "",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "Куб зеленный",
                        Description = "Зеленный",
                        Img = "",
                        Price = 3699,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                };
            }
        }
    }
}
