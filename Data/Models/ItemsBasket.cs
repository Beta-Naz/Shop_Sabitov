namespace Shop.Data.Models
{
    public class ItemsBasket : Item
    {
        public int Count { get; set; }

        public ItemsBasket(int count, Item item) : base(item)
        {
            this.Count = count;
        }

        public ItemsBasket() { }
    }

}
