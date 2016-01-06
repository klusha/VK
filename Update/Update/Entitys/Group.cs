using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Entity
{
    public class Group : VkEntity
    {
        public Group(int ID, String vkid)
        {
            this.SetId(ID);
            this.SetVkId(vkid);
        }
        public Group(String vkid)
        {
            this.SetVkId(vkid);
        }
    }
}
