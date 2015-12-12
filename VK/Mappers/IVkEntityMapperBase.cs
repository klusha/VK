using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    interface IVkEntityMapperBase<T> where T : VkEntity
    {
        //DBMaster dbMaster = new DBMaster();
        //abstract void Update(T user) { }
        void Insert(List<T> user);
        //void Delete(T user);

        T FindById(int id);
        //T FindByVkId(String id);
    }
}
