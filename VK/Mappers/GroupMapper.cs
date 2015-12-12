using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    public class GroupMapper : IVkEntityMapperBase<Group>
    {
        private DBMaster dbMaster = new DBMaster();
        //        public void Update(Group user);
        public void Insert(List<Group> groups)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();

            foreach (var group in groups)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO Groups (id_vk) VALUES (\"" + group.GetVkId() + "\")";
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }

        //        public void Delete(Group user);

        private Group FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            Group group = null;
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        group = new Group(Convert.ToInt32(reader["id"]), reader["id_vk"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return group;
        }

        public Group FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groups WHERE id = " + id;
            Group group = FindBy(SQL);
            return group;
        }
        public Group FindByVkId(String vkid)
        {
            String SQL = "";
            SQL = "SELECT * FROM Groups WHERE id_vk = " + vkid;
            Group group = FindBy(SQL);
            return group;
        }
    }
}
