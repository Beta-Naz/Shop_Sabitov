namespace Shop.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public Category? Category { get; set; }
        public Item(Item item = null)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Img = item.Img;
                Price = item.Price;
                Category = item.Category;
            }
        }
    }
}
   
