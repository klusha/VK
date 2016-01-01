using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Entity;

namespace Top.Mappers
{
    public class ListFriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();
        
        private List<int> FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            List<int> listFriends = new List<int>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listFriends.Add(Convert.ToInt32(reader["id_friend"]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return listFriends;
        }

        public List<int> FindByIdUser(int idUser)
        {
            String SQL = "";
            SQL = "SELECT * FROM listfriends WHERE id_user = " + idUser;
            List<int> listFriends = FindBy(SQL);
            return listFriends;
        }
    }
}
