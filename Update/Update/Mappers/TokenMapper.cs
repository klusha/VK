using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Update.Mappers
{
    class TokenMapper
    {
        private DBMaster dbMaster = new DBMaster();

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
