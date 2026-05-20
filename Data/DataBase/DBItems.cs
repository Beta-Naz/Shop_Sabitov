using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
namespace Shop.Data.DataBase
{
    public class DBItems : IItem
    {
        public IEnumerable<Category> Categories = new DBCategory().AllCategories;

        public IEnumerable<Item> AllItems
        {
            get
            {
                List<Item> items = new List<Item>();
                MySqlConnection MySqlConnection = Connection.CreateConnection();
                MySqlDataReader ItemsData = Connection.Query("SELECT * FROM shop.items ORDER BY `Name`;", MySqlConnection);
                while (ItemsData.Read())
                {
                    items.Add(new Item()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).FirstOrDefault()
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }
        public IEnumerable<Item> FindItems(string searchQuery)
        {
            List<Item> items = new List<Item>();
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            string sql = @"SELECT * FROM shop.items 
                          WHERE Name LIKE @search 
                          OR Description LIKE @search 
                          ORDER BY `Name`;";

            MySqlCommand command = new MySqlCommand(sql, MySqlConnection);
            command.Parameters.AddWithValue("@search", $"%{searchQuery}%");

            MySqlDataReader ItemsData = command.ExecuteReader();

            while (ItemsData.Read())
            {
                items.Add(new Item()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).FirstOrDefault()
                });
            }
            MySqlConnection.Close();
            return items;
        }
        public int Add(Item Item)
        {
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            Connection.Query(
                $"INSERT INTO `items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) VALUES " +
                $"('{Item.Name}', '{Item.Description}', '{Item.Img}', {Item.Price}, {Item.Category.Id});",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            MySqlConnection = Connection.CreateConnection();
            MySqlDataReader mySqlDataReaderItem = Connection.Query(
                $"SELECT `Id` FROM `items` WHERE `Name` = " +
                $"'{Item.Name}' AND `Description` = '{Item.Description}' AND " +
                $"`Price` = {Item.Price} AND `IdCategory` = {Item.Category.Id};",
                MySqlConnection);
            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }
    }
}
