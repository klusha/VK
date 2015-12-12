using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    public class FriendsMapper : IVkEntityMapperBase<Friend>
    {
        private DBMaster dbMaster = new DBMaster();
        //public void Update(Friends user);
        public void Insert(List<Friend> friends)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            foreach (var friend in friends)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO Friends (id_vk) VALUES (\"" + friend.GetVkId() + "\")";
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }
        //        public void Delete(Friends user);

        private Friend FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            Friend friend = null;
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        friend = new Friend(Convert.ToInt32(reader["id"]), reader["id_vk"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return friend;
        }

        public Friend FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM Friends WHERE id = " + id;
            Friend friend = FindBy(SQL);
            return friend;
        }
        public Friend FindByVkId(string vkid)
        {
            String SQL = "";
            SQL = "SELECT * FROM Friends WHERE id_vk = " + vkid;
            Friend friend = FindBy(SQL);
            return friend;
        }
    }
}
