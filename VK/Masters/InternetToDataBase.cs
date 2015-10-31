using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VK.Entity;
using VK.Mappers;

namespace VK.Masters
{
    public class InternetToDataBase
    {
        private VKClient vkClient;
        private String URL;

        public InternetToDataBase(String URL)
        {
            vkClient = new VKClient();
            this.URL = URL;
        }

        public void InsertToUsers()
        {
            User user = new User(vkClient.GetId(URL), vkClient.GetName(URL).ElementAt(0),
                                 vkClient.GetName(URL).ElementAt(1));
            UserMapper userMapper = new UserMapper();
            userMapper.Insert(user);
        }

        private void InsertToFriends(List<String> ListFriends)
        {
            FriendsMapper friendsMapper = new FriendsMapper();
            //List<Friend> ListFriends = new List<Friend>();
            foreach (var friend in ListFriends)
            {
                friendsMapper.Insert(new Friend(friend));
            }
        }

        public void InsertToListFriends()
        {
            UserMapper userMapper = new UserMapper();
            FriendsMapper friendsMapper = new FriendsMapper();
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            User user = userMapper.FindByVkId(vkClient.GetId(URL));
            List<String> listFriends = vkClient.FriendsList(vkClient.GetId(URL));
            InsertToFriends(listFriends);
            foreach (var vkidFriend in listFriends)
            {
                Friend friend = friendsMapper.FindByVkId(vkidFriend);
                listFriendsMapper.Insert(new ListFriends(user.GetId(), friend.GetId()));
            }

        }

        public void InsertToGroup()
        {
            int i = 1;
            UserMapper userMapper = new UserMapper();
            User user = userMapper.FindByVkId(vkClient.GetId(URL));
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            List<ListFriends> listFriends = listFriendsMapper.FindByIdUser(user.GetId());
            FriendsMapper friendsMapper = new FriendsMapper();
            foreach (var friend in listFriends)
            {
                Friend friendObj = friendsMapper.FindById(friend.GetIdFriend());
                List<String> listgroup = vkClient.GroupsList(friendObj.GetVkId());
                int idFriend = friendsMapper.FindByVkId(friendObj.GetVkId()).GetId();
                foreach (var vkidGroup in listgroup)
                {
                    Group group = new Group(vkidGroup);
                    GroupMapper groupMapper = new GroupMapper();
                    groupMapper.Insert(group);
                    GroupsFriendsMapper groupsFriendsMapper = new GroupsFriendsMapper();
                    GroupsFriends groupsFriends = new GroupsFriends(idFriend, groupMapper.FindByVkId(vkidGroup).GetId());
                    groupsFriendsMapper.Insert(groupsFriends);
                }
                i++;
                Console.WriteLine("--------------------Friend number {0}", i);
                listgroup.Clear();
            }
            Console.WriteLine("ЧУуууууууваааакак готово!!!!!");
        }
    }
}
