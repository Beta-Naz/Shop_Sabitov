namespace Shop.Data.Models
{
    public class VMUpdateItem
    {
        public Item Item { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
