﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateUser.Entity;

namespace CreateUser.Mappers
{
    public class ListFriendsMapper
    {
        private DBMaster dbMaster = new DBMaster();

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
                                          + "VALUES (" + listFriends.GetIdUser() + ", " + listFriends.GetIdFriend() + ")";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dbMaster.CloseConnection();
        }

        private List<ListFriends> FindBy(String SQL)
        {
            dbMaster.OpenConnection();
            List<ListFriends> listFriends = new List<ListFriends>();
            try
            {
                MySqlCommand command = dbMaster.GetConnection().CreateCommand();
                command.CommandText = SQL;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listFriends.Add(new ListFriends(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["id_user"]), Convert.ToInt32(reader["id_friend"])));
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

        public ListFriends FindById(int id)
        {
            String SQL = "";
            SQL = "SELECT * FROM listfriends WHERE id = " + id;
            ListFriends listFriends = FindBy(SQL).ElementAt(0);
            return listFriends;
        }

        public List<ListFriends> FindByIdFriend(int idFriend)
        {
            String SQL = "";
            SQL = "SELECT * FROM listfriends WHERE id_friend = " + idFriend;
            List<ListFriends> listFriends = FindBy(SQL);
            return listFriends;
        }

        public List<ListFriends> FindByIdUser(int idUser)
        {
            String SQL = "";
            SQL = "SELECT * FROM listfriends WHERE id_user = " + idUser;
            List<ListFriends> listFriends = FindBy(SQL);
            return listFriends;
        }
    }
}
