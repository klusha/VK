using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    public class Entity
    {
        protected int Id;
        public int GetId()
        {
            return Id;
        }
        public void SetId(int Id)
        {
            this.Id = Id;
        }
    }
}
