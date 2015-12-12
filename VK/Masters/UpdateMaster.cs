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
    public class UpdateMaster
    {
        private List<String> newListVkIdFriend;
        private InternetToDataBase internetToDataBase;
        private User user;
        private IApi Api;

        public UpdateMaster(User user, IApi Api)
        {
            this.user = user;
            this.newListVkIdFriend = new List<String>();
            internetToDataBase = new InternetToDataBase(Api);
            this.Api = Api;
        }



        public void CurrentListFriends(User user)
        {
            //VKClient vkClient = new VKClient();
            newListVkIdFriend.AddRange(Api.FriendsList(user.GetVkId()));
        }

        public void Update()
        {
            List<String> addedFriends = new List<String>();
            ListFriendsMapper listFriends = new ListFriendsMapper();
            List<String> oldListVkIdFriend = new List<String>();

            FriendsMapper friendsMapper = new FriendsMapper();
            try
            {
                foreach (var listFriend in listFriends.FindByIdUser(this.user.GetId()))
                {
                    int idFriend = listFriend.GetIdFriend();
                    oldListVkIdFriend.Add(friendsMapper.FindById(idFriend).GetVkId());
                }
                CurrentListFriends(this.user);
                int i = 0;
                foreach (var newVkIdFriend in this.newListVkIdFriend)
                {
                    foreach (var oldVkIdFriend in oldListVkIdFriend)
                    {
                        if (!newVkIdFriend.Equals(oldVkIdFriend))
                            i++;
                        else
                            break;
                    }
                    if (i == oldListVkIdFriend.Count)
                    {
                        addedFriends.Add(newVkIdFriend);
                    }
                    i = 0;
                }

                if (addedFriends.Count != 0)
                {
                    internetToDataBase.InsertToListFriends(this.user, addedFriends);
                    internetToDataBase.InsertToGroup(this.user, addedFriends);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("User is null");
                
            }
        }


    }
}
