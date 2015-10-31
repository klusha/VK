using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    public class UserMapper : IVkEntityMapperBase<User>
    {
        DBMaster dbMaster = new DBMaster();
        //public void Update(User user);
        public void Insert(User user)
        {
            //DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "INSERT INTO Users (last_name, first_name, id_vk) VALUES (\""
                                        + user.GetLastName() + "\", \"" + user.GetFirstName() + "\", \"" + user.GetVkId() + "\")";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }
        //public void Delete(User user);

        private User FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            User user = null;
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User(Convert.ToInt32(reader["id"]), reader["id_vk"].ToString(),
                                             reader["last_name"].ToString(), reader["first_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return user;
        }

        public User FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM Users WHERE id = " + id;
            User user = FindBy(SQL);
            return user;
        }

        public User FindByVkId(String vkid)
        {
            String SQL = "";
            SQL = "SELECT * FROM Users WHERE id_vk = " + vkid;
            User user = FindBy(SQL);
            return user;
        }
    }
}
