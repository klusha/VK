using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK
{
    public class StatisticsMaster
    {
        HTTPMaster httpMaster = new HTTPMaster();
        JSONMaster jsonMaster = new JSONMaster();


        public Dictionary<int, int> RepeatGroups(List<int> IdGroups)
        {
            Dictionary<int, int> massRepeatGroups = new Dictionary<int, int>();
            foreach (var currIdGroup in IdGroups)
            {
                int count = 0;
                foreach (var nextIdGroup in IdGroups)
                {
                    if (currIdGroup.Equals(nextIdGroup))
                        count++;
                }
                try
                {
                    massRepeatGroups.Add(currIdGroup, count);
                } catch (Exception ex)
                {
                }                
                //IdGroups.Distinct();
                //IdGroups.RemoveRange(i, count > 0 ? count + 1 : count);
            }
            return massRepeatGroups;
        }


        public Dictionary<String, int> RepeatGroups(Dictionary<String, List<String>> MapGroups)
        {
            Dictionary<String, int> MassRepeatGroups = new Dictionary<String, int>();
            int i = 0;
            foreach (var human in MapGroups)
            {
                int count = human.Value.Count(); // у i-го чувака количество подписок
                for (int j = 0; j < count; j++)
                {
                    String name = human.Value.ElementAt(j);
                    if (MassRepeatGroups.ContainsKey(name))
                    {
                        int kol = MassRepeatGroups[name];
                        MassRepeatGroups[name] = ++kol;
                    }
                    else
                    {
                        MassRepeatGroups[name] = 1; // если группы не было в списке
                    }
                }
                i++;
            }

            return MassRepeatGroups;
        }

        public Dictionary<int, int> SortGroups(Dictionary<int, int> MassRepeatGroups)
        {
            int i = 1;
            Dictionary<int, int> result = new Dictionary<int, int>();
            var items = from pair in MassRepeatGroups
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<int, int> pair in items)
            {
               result.Add(pair.Key, pair.Value);
               i++;
            }
            return result;
        }

        public Dictionary<String, int> SortGroups(Dictionary<String, int> MassRepeatGroups, int quantity)
        {
            int i = 1;
            Dictionary<String, int> result = new Dictionary<String, int>();
            var items = from pair in MassRepeatGroups
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, int> pair in items)
            {
                if (i <= quantity)
                {
                    result.Add(pair.Key, pair.Value);                    
                    i++;
                }
                else break;
            }
            return result;
        }

        public void PrintTop(Dictionary<String, int> MassRepeatGroups, int quantity)
        {
            int i = 1;
            MassRepeatGroups = SortGroups(MassRepeatGroups, quantity);
            foreach (var groupID in MassRepeatGroups)
            {
                Console.WriteLine(i + "-ое место: {0}: {1}", GetNameGroup(groupID.Key), groupID.Value);
                i++;
            }
        }

        //public void SortGroups(Dictionary<String, int> MassRepeatGroups, int quantity)
        //{
        //    int i = 1;
        //    var items = from pair in MassRepeatGroups
        //                orderby pair.Value descending
        //                select pair;
        //    foreach (KeyValuePair<string, int> pair in items)
        //    {
        //        if (i <= quantity)
        //        {
        //            Console.WriteLine(i + "-ое место: {0}: {1}", GetNameGroup(pair.Key), pair.Value);
        //            i++;
        //        }
        //        else break;
        //    }
        //}

        public String GetNameGroup(String id)
        {
            String nameGroup = "";
            String html = httpMaster.PageData("groups.getById", "group_id=" + id);
            nameGroup = jsonMaster.GetNameGroupOfJSON(html);
            return nameGroup;
        }
    }
}
