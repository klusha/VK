using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Update.Api
{
    public class VKClient : IApi
    {
        private HTTPMaster httpMaster = new HTTPMaster();
        private JSONMaster jsonMaster = new JSONMaster();        

        public List<String> GroupsList(String vkId)
        {
            List<String> ListGroups = new List<String>();
            StringBuilder param = new StringBuilder("user_id=");
            param.Append(vkId);
            String token = @"&access_token=b7d507c897d5b6f9f0450e8a435cd8cab52d6d64c96f66de2c7b3cadd342a2bc4c450c806cc39ae5c23c1";
            String json = httpMaster.PageData("groups.get", param.ToString() + token + "&v=5.37");
            ListGroups = jsonMaster.GetGroupsListOfJSON(json);
            return ListGroups;
        }       
    }
}
