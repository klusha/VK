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
    class Top
    {
        private List<String> currentListVkIdFriend;
        private IApi Api;

        public Top(IApi Api)
        {
            this.Api = Api;
            this.currentListVkIdFriend = new List<String>();
        }

        public void CurrentListFriends(User user)
        {
            //VKClient vkClient = new VKClient();           
            currentListVkIdFriend.AddRange(Api.FriendsList(user.GetVkId()));
        }

        public void CreateTop(User user)
        {
            Console.WriteLine("Создание топа...");
            UserMapper usersMapper = new UserMapper();
            user = usersMapper.FindByVkId(user.GetVkId());
            GroupsFriendsMapper groupFriendsMapper = new GroupsFriendsMapper();
            FriendsMapper friendsMapper = new FriendsMapper();
            List<GroupsFriends> groupsFriends = new List<GroupsFriends>();
            List<int> IdGroups = new List<int>();
            Tops tops;
            TopsMapper topsMapper = new TopsMapper();
            foreach (var VkId in currentListVkIdFriend)
            {
                friendsMapper.FindByVkId(VkId);
                foreach (var groupsFriend in groupFriendsMapper.FindByIdFriend(friendsMapper.FindByVkId(VkId).GetId()))
                {
                    IdGroups.Add(groupsFriend.GetIdGroup());
                }
            }
            StatisticsMaster statisticsMaster = new StatisticsMaster();
            //statisticsMaster.RepeatGroups(IdGroups);
            //statisticsMaster.SortGroups(statisticsMaster.RepeatGroups(IdGroups));
            tops = new Tops(statisticsMaster.SortGroups(statisticsMaster.RepeatGroups(IdGroups)), user.GetId());
            topsMapper.Insert(tops);
            Console.WriteLine("Топ создан!!!");
        }

        public Tops FindTop(DateTime date)
        {
            Tops tops = new Tops();
            TopsMapper topsMapper = new TopsMapper();
            tops = topsMapper.FindByDate(date.ToString("dd.MM.yyyy"));
            return tops;
        }



    }
}
