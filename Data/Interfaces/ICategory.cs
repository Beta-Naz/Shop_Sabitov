using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface ICategory
    {
        public IEnumerable<Category> AllCategories { get;}
        public Category GetCategory(int id);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(int id);
    }
}
