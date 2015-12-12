using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK.Entity;

namespace VK.Mappers
{
    interface IEntityMapperBase<T> where T : Entity.Entity
    {
        //DBMaster dbMaster = new DBMaster();
        //abstract void Update(T user) { }
        void Insert(T user);
        //void Delete(T user);

        T FindById(int id);
        //T FindByVkId(String id);
    }
}
