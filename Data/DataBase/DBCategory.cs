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
        public Category GetCategory(int id)
        {
            Category category = null;
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            string sql = $"SELECT * FROM shop.categorys WHERE Id = {id};";
            MySqlDataReader CategorysData = Connection.Query(sql, MySqlConnection);

            if (CategorysData.Read())
            {
                category = new Category()
                {
                    Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                    Name = CategorysData.IsDBNull(1) ? "" : CategorysData.GetString(1),
                    Description = CategorysData.IsDBNull(2) ? "" : CategorysData.GetString(2)
                };
            }
            MySqlConnection.Close();
            return category;
        }

        public void Add(Category category)
        {
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            string insertQuery = $"INSERT INTO `categorys` (`Name`, `Description`) VALUES ('{category.Name}', '{category.Description}');";
            Connection.Query(insertQuery, MySqlConnection);
            MySqlConnection.Close();
        }

        public void Update(Category category)
        {
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            string updateQuery = $"UPDATE `categorys` SET `Name` = '{category.Name}', `Description` = '{category.Description}' WHERE `Id` = {category.Id};";
            Connection.Query(updateQuery, MySqlConnection);
            MySqlConnection.Close();
        }

        public void Delete(int id)
        {
            MySqlConnection MySqlConnection = Connection.CreateConnection();
            string deleteQuery = $"DELETE FROM `categorys` WHERE `Id` = {id};";
            Connection.Query(deleteQuery, MySqlConnection);
            MySqlConnection.Close();
        }
    }
}
