using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Update.Entity;

namespace Update.Mappers
{
    public class GroupsFriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(int idFriend, List<Group> groups)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();

            foreach (var group in groups)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO Groupsfriends (id_friend, id_group) "
                                          + "VALUES (" + idFriend + ", " + group.GetId() + ")";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }

        public void deleteAllRecord()
        {
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "DELETE FROM Groupsfriends";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }
    }
}
