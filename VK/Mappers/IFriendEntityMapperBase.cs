using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    interface IFriendEntityMapperBase<T> where T : EntityFriends
    {
        //public DBMaster dbMaster = new DBMaster();
        //void Update(T user);
        void Insert(T user);
        //        void Delete(T user);

        //        T FindById(int id);
        //        T FindByIdFriend(String id_friend);
    }
}
