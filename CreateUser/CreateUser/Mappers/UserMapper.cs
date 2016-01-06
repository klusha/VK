using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateUser.Entity;
using CreateUser.Project;

namespace CreateUser.Mappers
{
    public class UserMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(User user)
        {
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

        public void Update(UserToCreate user)
        {
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "UPDATE Users SET status = 1 WHERE vk_id = @idUser";
                command.Parameters.AddWithValue("@idUser", user.vk_id);

                command.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
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
