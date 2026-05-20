using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.DataBase
{
    public class DBCategory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                List<Category> categories = new List<Category>();
                MySqlConnection MySqlConnection = Connection.CreateConnection();
                MySqlDataReader CategorysData = Connection.Query("SELECT * FROM shop.categorys ORDER BY `Name`;", MySqlConnection);
                while (CategorysData.Read())
                {
                    categories.Add(new Category()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? "null" : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? "null" : CategorysData.GetString(2)
                    });
                }
                return categories;
            }
        }
    }
}
