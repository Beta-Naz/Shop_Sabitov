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

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
