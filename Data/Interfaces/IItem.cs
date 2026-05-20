using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IItem
    {
        public IEnumerable<Item> AllItems { get; }
        public IEnumerable<Item> FindItems(string searchQuery);
        public int Add(Item item);
        public Item GetItem(int id);
        public void Update(Item item);
        public void Delete(int id);
    }
}
