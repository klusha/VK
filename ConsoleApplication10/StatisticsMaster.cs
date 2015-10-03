using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK
{
    public class StatisticsMaster
    {
        public static Dictionary<String, int> RepeatGroups(Dictionary<String, List<String>> MapGR)
        {
            Dictionary<String, int> MassRepeatGroups = new Dictionary<String, int>();
            for (int i = 0; i < MapGR.Count(); i++)
            {
                int count = MapGR.ElementAt(i).Value.Count(); // у i-го чувака количество подписок
                for (int j = 0; j < count; j++)
                {
                    String name = MapGR.ElementAt(i).Value.ElementAt(j);
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
            }
            return MassRepeatGroups;
        }

        public static void SortGroups(Dictionary<String, int> MassRepeatGroups, int quantity)
        {
            int i = 1;
            var items = from pair in MassRepeatGroups
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, int> pair in items)
            {
                if (i <= quantity)
                {
                    Console.WriteLine(i + "-ое место: {0}: {1}", GetNameGroup(pair.Key), pair.Value);
                    i++;
                }
                else break;
            }
        }

        public static String GetNameGroup(String id)
        {
            String nameGroup = "";
            String html = VK.HTTPMaster.PageData("groups.getById", "group_id=" + id);
            nameGroup = VK.JSONMaster.GetNameGroup_Of_JSON(html);
            return nameGroup;
        }
    }
}
