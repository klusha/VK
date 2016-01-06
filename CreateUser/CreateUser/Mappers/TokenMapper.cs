using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CreateUser.Project;
using MySql.Data.MySqlClient;

namespace CreateUser.Mappers
{
    class TokenMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(UserToCreate user)
        {
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "INSERT INTO userstokens (id_user, token) "
                         + "VALUES ((SELECT id FROM Users WHERE id_vk = @vkid), @token)";
                command.Parameters.AddWithValue("@vkid", user.vk_id);
                command.Parameters.AddWithValue("@token", user.token);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }

        public String FindByUserID(String idUser)
        {
            dbMaster.OpenConnection();
            String token = "";
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "SELECT token FROM userstokens WHERE id_user = "
                    + "(SELECT id FROM Users WHERE id_vk = @idUser)";
                command.Parameters.AddWithValue("@idUser", idUser);
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        token = reader["token"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return token;
        }
    }
}
