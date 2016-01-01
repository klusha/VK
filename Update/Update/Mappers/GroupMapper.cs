using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Update.Entity;

namespace Update.Mappers
{
    public class GroupMapper
    {
        private DBMaster dbMaster = new DBMaster();

        public void Insert(List<String> groups)
        {
            DBMaster dbMaster = new DBMaster();
            dbMaster.OpenConnection();

            foreach (var group in groups)
            {
                try
                {
                    MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                    command.CommandText = "INSERT INTO Groups (id_vk) VALUES (\"" + group + "\")";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }

        public List<Group> AllGroups(List<String> vkIdGroups)
        {
            dbMaster.OpenConnection();
            List<Group> groups = new List<Group>();
            StringBuilder param = new StringBuilder("(");
            if (vkIdGroups.Count > 0)
            {
                param.Append(vkIdGroups.First());
                foreach (var vkIdGroup in vkIdGroups)
                {
                    param.Append(",").Append(vkIdGroup);
                }
                param.Append(")");
            }

            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = "SELECT * FROM Groups WHERE id_vk in " + param.ToString();
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group(Convert.ToInt32(reader["id"]), reader["id_vk"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dbMaster.CloseConnection();
            return groups;
        }        
    }
}
