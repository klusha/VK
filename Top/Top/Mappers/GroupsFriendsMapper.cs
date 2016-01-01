using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Entity;

namespace Top.Mappers
{
    public class GroupsFriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();
        
        private List<int> FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            List<int> groupsFriends = new List<int>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groupsFriends.Add(Convert.ToInt32(reader["id_group"]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return groupsFriends;
        }

        public GroupsFriends FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM GroupsFriends WHERE id = " + id;
            GroupsFriends groupsFriends = null;
            return groupsFriends;
        }

        public List<int> FindByIdFriend(int idFriend)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groupsfriends WHERE id_friend = " + idFriend;
            List<int> groupsFriends = FindBy(SQL);
            return groupsFriends;
        }

        public List<int> FindByIdGroup(int idGroup)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groupsfriends WHERE id_group = " + idGroup;
            List<int> groupsFriends = FindBy(SQL);
            return groupsFriends;
        }
    }
}
