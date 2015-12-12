using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VK.Entity;
using VK.Mappers;
using VK.Api;

namespace VK.Masters
{
    public class InternetToDataBase
    {
        private IApi vkClient;
        private String URL;

        public InternetToDataBase(IApi VkClient)
        {
            vkClient = VkClient;
        }

        public InternetToDataBase(String URL, IApi VkClient)
        {
            vkClient = VkClient;
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
            List<Friend> friends = null;
            //List<Friend> ListFriends = new List<Friend>();
            friends = new List<Friend>();
            foreach (var friend in ListFriends)
            {
                friends.Add(new Friend(friend));
            }
            friendsMapper.Insert(friends);
        }
        
        public void InsertToListFriends(User user, List<String> listFriends)
        {
            UserMapper userMapper = new UserMapper();
            FriendsMapper friendsMapper = new FriendsMapper();
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            //User user = userMapper.FindByVkId(vkClient.GetId(URL));
            //List<String> listFriends = vkClient.FriendsList(vkClient.GetId(URL));
            InsertToFriends(listFriends);
            List<ListFriends> ListFriendses = new List<ListFriends>();
            foreach (var vkidFriend in listFriends)
            {
                Friend friend = friendsMapper.FindByVkId(vkidFriend);
                ListFriendses.Add(new ListFriends(user.GetId(), friend.GetId()));
            }
            listFriendsMapper.Insert(ListFriendses);
        }
        
        public void InsertToListFriends()
        {
            UserMapper userMapper = new UserMapper();
            FriendsMapper friendsMapper = new FriendsMapper();
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            User user = userMapper.FindByVkId(vkClient.GetId(URL));
            List<String> listFriends = vkClient.FriendsList(vkClient.GetId(URL));
            InsertToFriends(listFriends);
            List<ListFriends> ListFriendses = new List<ListFriends>();
            foreach (var vkidFriend in listFriends)
            {
                Friend friend = friendsMapper.FindByVkId(vkidFriend);
                ListFriendses.Add(new ListFriends(user.GetId(), friend.GetId()));
            }
            listFriendsMapper.Insert(ListFriendses);
        }

        public void InsertToGroup(User user, List<String> listVkIdFriends)
        {
            int i = 1;
            UserMapper userMapper = new UserMapper();
            //User user = userMapper.FindByVkId(vkClient.GetId(URL));
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            List<ListFriends> listFriends = new List<ListFriends>();
            FriendsMapper friendsMapper = new FriendsMapper();
            foreach (var vkIdFriend in listVkIdFriends)
            {
                ListFriends listFriend = new ListFriends(user.GetId(), friendsMapper.FindByVkId(vkIdFriend).GetId());
                listFriends.Add(listFriend);
            }
            //List<ListFriends> listFriends = listFriendsMapper.FindByIdUser(user.GetId());
            //FriendsMapper friendsMapper = new FriendsMapper();
            foreach (var friend in listFriends)
            {
                GroupMapper groupMapper = new GroupMapper();
                Friend friendObj = friendsMapper.FindById(friend.GetIdFriend());
                String VkId = friendObj.GetVkId();


                List<String> listgroup = vkClient.GroupsList(VkId);
                List<Group> groupsFriend = new List<Group>(); ;
                List<GroupsFriends> GroupsFriendses = new List<GroupsFriends>();
                int idFriend = friendsMapper.FindByVkId(friendObj.GetVkId()).GetId();
                GroupsFriendsMapper groupsFriendsMapper = new GroupsFriendsMapper();
                Group group = null;
                foreach (var vkidGroup in listgroup)
                {
                    group = new Group(vkidGroup);
                    groupsFriend.Add(group);
                }
                groupMapper.Insert(groupsFriend);

                foreach (var vkidGroup in listgroup)
                {
                    GroupsFriends groupsFriends = new GroupsFriends(idFriend, groupMapper.FindByVkId(vkidGroup).GetId());
                    GroupsFriendses.Add(groupsFriends);
                }
                groupsFriendsMapper.Insert(GroupsFriendses);
                Console.WriteLine("--------------------Friend number {0}", i);
                i++;
                listgroup.Clear();
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
                GroupMapper groupMapper = new GroupMapper();
                Friend friendObj = friendsMapper.FindById(friend.GetIdFriend());
                List<String> listgroup = vkClient.GroupsList(friendObj.GetVkId());
                List<Group> groupsFriend = new List<Group>(); ;
                List<GroupsFriends> GroupsFriendses = new List<GroupsFriends>();
                int idFriend = friendsMapper.FindByVkId(friendObj.GetVkId()).GetId();
                GroupsFriendsMapper groupsFriendsMapper = new GroupsFriendsMapper();
                Group group = null;
                foreach (var vkidGroup in listgroup)
                {
                    group = new Group(vkidGroup);
                    groupsFriend.Add(group);                   
                }
                groupMapper.Insert(groupsFriend);

                foreach (var vkidGroup in listgroup)
                {
                    GroupsFriends groupsFriends = new GroupsFriends(idFriend, groupMapper.FindByVkId(vkidGroup).GetId());
                    GroupsFriendses.Add(groupsFriends);
                }
                groupsFriendsMapper.Insert(GroupsFriendses);        
                Console.WriteLine("--------------------Friend number {0}", i);
                i++;
                listgroup.Clear();
            }
            Console.WriteLine("ЧУуууууууваааак готово!!!!!");
        }
    }
}
