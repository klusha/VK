using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Update.Mappers;
using Update.Entity;
using Update.Api;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            Producer producer = new Producer();
            FriendsMapper friendsMapper = new FriendsMapper();
            GroupMapper groupMapper = new GroupMapper();
            GroupsFriendsMapper groupsFriendsMapper = new GroupsFriendsMapper();
            List<Group> groups = new List<Group>();
            IApi vkClient = new VKClient();
            groupsFriendsMapper.deleteAllRecord();
            while (true)
            {
                List<String> listGroups = new List<String>();
                String vkIdFriend = consumer.Receive("ToUpdate");
                Console.WriteLine("Обновление друга с vkIdFriend = {0}", vkIdFriend);
                int idFriend = friendsMapper.FindByVkId(vkIdFriend).GetId();
                listGroups.AddRange(vkClient.GroupsList(vkIdFriend));
                groupMapper.Insert(listGroups);
                groups.AddRange(groupMapper.AllGroups(listGroups));
                groupsFriendsMapper.Insert(idFriend, groups);
                producer.SendMessage(vkIdFriend, "FromUpdate");
            }            
        }
    }
}
