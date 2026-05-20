using Shop.Data.Models;

namespace Shop.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Category> Categorys {get; set;}
        public int SelectCategory = 0;
        public string SortOrder = "default";
        public string SearchString { get; set; }
    }
}
