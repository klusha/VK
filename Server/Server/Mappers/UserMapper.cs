using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Mappers
{
    public class UserMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public List<User> FindByAllRecord()
        {
            dbMaster.OpenConnection();
            List<User> userList = new List<User>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "SELECT * FROM Users";
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userList.Add( new User(Convert.ToInt32(reader["id"]),
                                                               reader["id_vk"].ToString(),
                                                               reader["last_name"].ToString(), 
                                                               reader["first_name"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return userList;
        }
    }
}
