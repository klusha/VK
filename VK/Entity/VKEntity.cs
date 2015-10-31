using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.Entity
{
    public class VkEntity : Entity
    {
        protected String VkId;
        public String GetVkId()
        {
            return VkId;
        }
        public void SetVkId(String vkID)
        {
            this.VkId = vkID;
        }
    }
}
