using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    public class GroupsFriendsMapper : IFriendEntityMapperBase<GroupsFriends>
    {
        DBMaster dbMaster = new DBMaster();
        //public void Update(GroupsFriends user);
        public void Insert(GroupsFriends groupsFriends)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                //command.CommandText = "INSERT INTO GroupsFriends (id_friend , id_group )"
                //                + "VALUES ((SELECT id_friend FROM friends WHERE id_friend_vk = \"" + friend.GetVkId() + "\"),"
                //                + "(SELECT id_group FROM Groups WHERE id_group_vk = \"" + group.GetVkId() + "\" ))";

                command.CommandText = "INSERT INTO Groupsfriends (id_friend, id_group) "
                                      + "VALUES (" + groupsFriends.GetIdFriend() + ", " + groupsFriends.GetIdGroup() + ")";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }

        private List<GroupsFriends> FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            List<GroupsFriends> groupsFriends = new List<GroupsFriends>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groupsFriends.Add(new GroupsFriends(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["id_friend"]), Convert.ToInt32(reader["id_group"])));
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
        //        public void Delete(GroupsFriends user);

        public GroupsFriends FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM GroupsFriends WHERE id = " + id;
            GroupsFriends groupsFriends = FindBy(SQL).ElementAt(0);
            return groupsFriends;
        }

        public List<GroupsFriends> FindByIdFriend(int idFriend)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groupsfriends WHERE id_friend = " + idFriend;
            List<GroupsFriends> groupsFriends = FindBy(SQL);
            return groupsFriends;
        }

        public List<GroupsFriends> FindByIdGroup(int idGroup)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groupsfriends WHERE id_group = " + idGroup;
            List<GroupsFriends> groupsFriends = FindBy(SQL);
            return groupsFriends;
        }
    }
}
