using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface ICategory
    {
        public IEnumerable<Category> AllCategories { get;}
    }
}
