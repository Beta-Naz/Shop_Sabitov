using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IItem
    {
        public IEnumerable<Item> AllItems { get; }
    }
}
