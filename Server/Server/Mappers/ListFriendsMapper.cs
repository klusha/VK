using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Mappers
{
    public class ListFriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void executeQuery(String SQL)
        {
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }

        public void deleteRecord(int vkIdFriend)
        {
            String SQL = "DELETE FROM ListFriendsForServer WHERE id_friend = " + vkIdFriend;
            executeQuery(SQL);
        }

        public void deleteAllRecord()
        {
            String SQL = "DELETE FROM ListFriendsForServer";
            executeQuery(SQL);
        }

        public void Insert(List<ListFriends> listFriendses)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();

            foreach (var listFriends in listFriendses)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO ListFriends (id_user, id_friend) "
                                          + "VALUES (" + listFriends.GetIdUser() + ", (SELECT id FROM friends WHERE id_vk = " + listFriends.GetVkIdFriend() + "))";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO listfriendsforserver (id_user, id_friend) "
                                          + "VALUES (" + listFriends.GetIdUser() + ", " + listFriends.GetVkIdFriend() + ")";
                    command.ExecuteNonQuery();

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }


        // Функция для выполнения запросов на получение записей
        public int countRecord(String SQL)
        {
            dbMaster.OpenConnection();
            int count = 0;
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        count = Convert.ToInt32(reader["count(1)"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return count;
        }
        // Количество записей в таблице
        public int countAllRecord()
        {
            String SQL = "";
            SQL = "SELECT count(1) FROM ListFriendsForServer";
            int count = countRecord(SQL);
            return count;
        }
        // Количество записей для конкретного пользователя
        public int countRecordForUser(int idUser)
        {
            String SQL = "";
            SQL = "SELECT count(1) FROM ListFriendsForServer WHERE id_user = " + idUser;
            int count = countRecord(SQL);
            return count;
        }
    }
}
