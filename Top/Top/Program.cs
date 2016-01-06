using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Entity;
using Top.Mappers;

namespace Top
{
    class Program
    {
        public static Dictionary<int, int> RepeatGroups(List<int> IdGroups)
        {
            Dictionary<int, int> massRepeatGroups = new Dictionary<int, int>();
            foreach (var currIdGroup in IdGroups)
            {
                int count = 0;
                foreach (var nextIdGroup in IdGroups)
                {
                    if (currIdGroup.Equals(nextIdGroup))
                    {
                        count++;                        
                    }
                }
                try
                {
                    massRepeatGroups.Add(currIdGroup, count);
                }
                catch (Exception ex)
                {
                }
            }
            return massRepeatGroups;
        }




        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            ListFriendsMapper listFriendsMapper = new ListFriendsMapper();
            GroupsFriendsMapper groupsFriendsMapper = new GroupsFriendsMapper();
            TopMapper topMapper = new TopMapper();
            List<int> listFriends = new List<int>();
            List<int> allIdGroups = new List<int>();            
            
            while (true)
            {
                int idUser = Convert.ToInt32(consumer.Receive("ToTop"));
                Console.WriteLine("Обновление пользователя с Id = {0}", idUser);
                // получить обновленный (актуальный) список друзей
                listFriends.AddRange(listFriendsMapper.FindByIdUser(idUser));

                foreach (var idFriend in listFriends)
                {
                    // Получаем список групп всех друзей
                    allIdGroups.AddRange(groupsFriendsMapper.FindByIdFriend(idFriend));
                }

                Top.Entity.Top top = new Top.Entity.Top(RepeatGroups(allIdGroups), idUser);
                topMapper.Insert(top);
            }            
        }
    }
}
