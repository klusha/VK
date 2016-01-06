using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Update.Entity;
using Update.Project;

namespace Update.Mappers
{
    public class UserMapper
    {
        private DBMaster dbMaster = new DBMaster();

        private String FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            String idUser = 0;
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idUser = Convert.ToString(reader["id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return idUser;
        }

        public String FindByVkId(String vkid)
        {
            String SQL = "";
            SQL = "SELECT id FROM Users WHERE id_vk = " + vkid;
            String user = FindBy(SQL);
            return user;
        }
    }
}
