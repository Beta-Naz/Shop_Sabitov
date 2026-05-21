namespace Shop.Data.Models
{
    public class ItemsBasket : Item
    {
        public int Count { get; set; }

        public ItemsBasket(int Count, Item item) : base(item)
        {
            this.Count = Count;
        }
    }

}
