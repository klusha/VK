using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Update.Mappers;

namespace Update.Api
{
    public class VKClient : IApi
    {
        private HTTPMaster httpMaster = new HTTPMaster();
        private JSONMaster jsonMaster = new JSONMaster();
        private String TOKEN = "";
        private String IDUSER = "";

        public List<String> GroupsList(String vkId)
        {
            List<String> ListGroups = new List<String>();
            StringBuilder param = new StringBuilder("user_id=");
            param.Append(vkId);
            UserMapper userMapper = new UserMapper();
            this.IDUSER = userMapper.FindByVkId(vkId);
            TokenMapper tokenMapper = new TokenMapper();
            this.TOKEN = tokenMapper.FindByUserID(this.IDUSER);
            String token = @"&access_token=" + this.TOKEN;
            String json = httpMaster.PageData("groups.get", param.ToString() + token + "&v=5.37");
            ListGroups = jsonMaster.GetGroupsListOfJSON(json);
            return ListGroups;
        }       
    }
}
