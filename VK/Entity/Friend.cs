using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    public class Friend : VkEntity
    {
        public Friend(String vkid)
        {
            VkId = vkid;
        }
        public Friend(int ID, String vkid)
        {
            this.SetId(ID);
            VkId = vkid;
        }
    }
}
