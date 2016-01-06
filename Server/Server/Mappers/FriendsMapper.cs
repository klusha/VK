using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Mappers
{
    public class FriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(List<String> vkIdFriends)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            foreach (var vkIdfriend in vkIdFriends)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO Friends (id_vk) VALUES (\"" + vkIdfriend + "\")";
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }

        public List<Friend> FindByAllRecord()
        {
            dbMaster.OpenConnection();
            List<Friend> friendList = new List<Friend>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "SELECT * FROM Friends";
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        friendList.Add(new Friend(Convert.ToInt32(reader["id"]),
                                                  reader["id_vk"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return friendList;
        }
    }
}
