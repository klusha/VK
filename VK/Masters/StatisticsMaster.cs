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
                    result.Add(GetNameGroup(pair.Key), pair.Value);
                    Console.WriteLine(i + "-ое место: {0}: {1}", GetNameGroup(pair.Key), pair.Value);
                    i++;
                }
                else break;
            }
            return result;
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
