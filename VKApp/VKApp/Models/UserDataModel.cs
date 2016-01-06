using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using VKApp.Project;

namespace VKApp.Models
{
    public class UserDataModel
    {
        public String URL { set; get; }
        private DBMaster dbMaster = new DBMaster();

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Введите дату")]
        public DateTime date { set; get; }
        public int quantity { set; get; }

        public UserDataModel()
        {
        }

        public bool ComplianceTest()
        {
            vkClient vk = new vkClient();
            this.URL = this.URL.Trim();
            if (!string.IsNullOrWhiteSpace(this.URL))
            {
                if (this.URL.StartsWith("http://vk.com/") | this.URL.StartsWith("https://vk.com/"))
                {
                    String vkID = vk.GetId(this.URL);
                    int status = dbMaster.FindByVkIDUser(vkID);
                    if (status == 1)
                        return true;
                    else return false;
                }
            }
            return false;
        }
    }
}