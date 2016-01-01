using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;
using Server.Mappers;
using Server.Entity;
using Server.Api;

namespace Server
{
    class Program
    {
        public static List<String> Preparation()
        {
            List<ListFriends> ListFriendses = new List<ListFriends>();
            FriendsMapper friendsMapper = new FriendsMapper();
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            listFriendsMapper.deleteAllRecord();
            UserMapper userMapper = new UserMapper();
            List<User> users = new List<User>();
            List<String> allVkIDFriends = new List<String>();   // Все друзья всех пользователей
            IApi vkClient = new VKClient();

            users = userMapper.FindByAllRecord();
            foreach (var user in users)
            {                
                String vkIDUser = user.GetVkId();
                List<String> vkIDFriends = new List<String>();  // Актуальный список друзей пользователя
                vkIDFriends.AddRange(vkClient.FriendsList(vkIDUser));
                friendsMapper.Insert(vkIDFriends);      // Заносим в БД актуальный список друщзей друзей

                foreach (var vkId in vkIDFriends)
                {
                    ListFriendses.Add(new ListFriends(user.GetId(), vkId)); // Заполнили таблицу для сервера
                }
                listFriendsMapper.Insert(ListFriendses);
                allVkIDFriends.AddRange(vkIDFriends); // Актуальный список друзей всех пользователей
            }
            List<String> uniqueVkIDFriends = new List<String>();
            uniqueVkIDFriends.AddRange(allVkIDFriends.Distinct().ToList()); // Уникальные записи о друзьях всех пользователей
            return uniqueVkIDFriends;
        }
        
        public static void ToUpdate()
        {
            Producer producer = new Producer();
            List<String> uniqueVkIDFriends = new List<String>();
            uniqueVkIDFriends.AddRange(Preparation());
            foreach (var vkIDFriend in uniqueVkIDFriends)
            {
                producer.SendMessage(vkIDFriend, "ToUpdate");
            }
        }

        public static void ToTop(int idUser)
        {
            Producer producer = new Producer();
            producer.SendMessage(idUser.ToString(), "ToTop");
        }

        public static void FromUpdate(ListFriendsMapper listFriendsMapper)
        {
            UserMapper userMapper = new UserMapper();
            List<User> users = new List<User>();
            users.AddRange(userMapper.FindByAllRecord());
            Consumer consumer = new Consumer();
            while (listFriendsMapper.countAllRecord() > 0)
            {
                int vkIdFriend = Convert.ToInt32(consumer.Receive("FromUpdate"));
                listFriendsMapper.deleteRecord(vkIdFriend);
                foreach (var user in users)
                {
                    int idUser = user.GetId();
                    if (listFriendsMapper.countRecordForUser(idUser) == 0)
                    {
                        ToTop(idUser);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            ToUpdate();
            FromUpdate(listFriendsMapper);
        }
    }
}
