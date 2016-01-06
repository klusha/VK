using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;


namespace VKApp.Project
{
    public class DBMaster
    {
        private readonly string connectionString = "Database=vk;Data Source=localhost;User Id=root;Password=; charset=utf8";
        
        public MySqlConnection OpenConnection()
        {
            var MyConnection = new MySqlConnection(connectionString);
            MyConnection.Open();
            return MyConnection;
        }

        public Dictionary<int, int> FindByDate(String date, int quantity, int idUser)
        {
            int i = 0;
            String SQL = "SELECT * FROM tops WHERE id_user = @idUser AND data = (SELECT STR_TO_DATE(@date, '%d.%m.%Y')) ORDER BY count DESC";
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            try
            {
                MySqlCommand command = this.OpenConnection().CreateCommand();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@idUser", idUser);
                command.Parameters.AddWithValue("@date", date);
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read() & (i < quantity))
                    {
                        dictionaryTops.Add(Convert.ToInt32(reader["id_group"]), Convert.ToInt32(reader["count"]));
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dictionaryTops;
        }

        public String FindByIdGroup(int idGroup)
        {
            String SQL = "SELECT * FROM Groups WHERE id = @idGroup";
            String vkIDGroup = "";
            try
            {
                MySqlCommand command = this.OpenConnection().CreateCommand();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@idGroup", idGroup);
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vkIDGroup = reader["id_vk"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vkIDGroup;
        }

        public void InsertToToken(List<String> userInfo)
        {
            String SQL = "INSERT INTO userstokens (id_user, token) "
                         + "VALUES ((SELECT id FROM Users WHERE id_vk = @vkid), @token)";
            try
            {
                MySqlCommand command = this.OpenConnection().CreateCommand();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@vkid", userInfo.ElementAt(1));
                command.Parameters.AddWithValue("@token", userInfo.ElementAt(0));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int FindByVkIDUser(String vkID)
        {
            int status = 0;
            try
            {
                MySqlCommand command = this.OpenConnection().CreateCommand();
                command.CommandText = "SELECT status FROM Users WHERE id_vk = @vkID";
                command.Parameters.AddWithValue("@vkID", vkID);
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        status = Convert.ToInt32(reader["status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status;
        }
        public int FindByIDUser(String vkID)
        {
            int IDUser = 0;
            try
            {
                MySqlCommand command = this.OpenConnection().CreateCommand();
                command.CommandText = "SELECT id FROM Users WHERE id_vk = @vkID";
                command.Parameters.AddWithValue("@vkID", vkID);
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IDUser = Convert.ToInt32(reader["id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return IDUser;
        }
    }    
}


