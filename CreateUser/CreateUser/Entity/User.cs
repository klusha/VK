using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUser.Entity
{
    public class User : VkEntity
    {
        private String last_name;
        private String first_name;

        public String GetLastName()
        {
            return last_name;
        }
        public String GetFirstName()
        {
            return first_name;
        }
        public User(String vkid, String lastname, String firstname)
        {
            VkId = vkid;
            last_name = lastname;
            first_name = firstname;
        }
        public User(int ID, String vkid, String lastname, String firstname)
        {
            this.SetId(ID);
            VkId = vkid;
            last_name = lastname;
            first_name = firstname;
        }
    }
}
