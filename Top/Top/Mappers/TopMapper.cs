using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Entity;
using MySql.Data.MySqlClient;

namespace Top.Mappers
{
    class TopMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(Top.Entity.Top top)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();

                foreach (var lineTop in top.GetDictionaryTops())
                {
                    command.CommandText = "INSERT INTO tops (id_group, count, data, id_user) "
                                          + "VALUES (" + lineTop.Key + ", " + lineTop.Value
                                          + ", DATE_FORMAT(CURRENT_DATE(), '%Y-%m-%d'), " +  top.GetUserID() + ")";
                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }
    }
}
