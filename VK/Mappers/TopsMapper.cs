using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;
using MySql.Data.MySqlClient;

namespace VK.Mappers
{
    class TopsMapper : IEntityMapperBase<Tops>
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(Tops tops)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();

                foreach (var lineTop in tops.GetDictionaryTops())
                {
                    command.CommandText = "INSERT INTO tops (id_group, count, data, id_user) "
                                          + "VALUES (" + lineTop.Key + ", " + lineTop.Value
                                          + ", DATE_FORMAT(CURRENT_DATE(), '%Y-%m-%d'), " +  tops.GetUserID() + ")";
                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
        }


        private Tops FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            Tops tops = null;
            String dateTops = "";
            Dictionary<int, int> dictionaryTops = new Dictionary<int, int>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dictionaryTops.Add(Convert.ToInt32(reader["id_group"]), Convert.ToInt32(reader["count"]));
                        dateTops = reader["data"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            tops = new Tops(dictionaryTops, dateTops);
            return tops;
        }

        public Tops FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM Tops WHERE id = " + id;
            Tops tops = FindBy(SQL);
            return tops;
        }

        public Tops FindByDate(String date)
        {
            String SQL = "";
            SQL = "SELECT * FROM tops WHERE data = (SELECT STR_TO_DATE('" + date + "', '%d.%m.%Y'))";
            Tops tops = FindBy(SQL);
            return tops;
        }

    }
}
