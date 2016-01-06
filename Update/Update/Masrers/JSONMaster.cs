using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Update
{
    class JSONMaster
    {
        private JObject jsonObj = new JObject();      

        public List<String> GetGroupsListOfJSON(String json)
        {
            List<String> ListGroups = new List<String>();
            jsonObj = JObject.Parse(json);
            try
            {
                foreach (var result in jsonObj["response"].Last)
                {
                    for (int i = 0; i < result.Count(); i++)
                    {
                        ListGroups.Add(result.ElementAt(i).ToString());
                    }
                }
            }
            catch (NullReferenceException ex)
            { 
            }
            return ListGroups;
        }     
    }
}
