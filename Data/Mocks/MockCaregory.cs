using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
    public class MockCaregory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>()
                {
                    new Category()
                    {
                        Id = 0,
                        Name = "Кубы",
                        Description = "Кубы имеют четыре угла"
                    },
                    new Category()
                    {
                        Id = 1,
                        Name = "Сферы",
                        Description = "Сферы не имеют углов"
                    },
                };
            }
        }
    }
}
