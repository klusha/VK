using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using VK;
using System.Linq;

namespace VKTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void IDUserTest()
        {
            VKClient vkClient = new VKClient();
            Assert.AreEqual("id25293291", vkClient.IDUser("https://vk.com/id25293291"));
        }

        [TestMethod]
        public void RepeatGroupsTest()
        {
            StatisticsMaster sm = new StatisticsMaster();
            Dic dic = new Dic();
            bool flag = false;
            Dictionary<String, int> Count = sm.RepeatGroups(dic.GroupList);
            if (Count.Count == dic.CountGroups.Count)
            {
                foreach (var data in Count)
                {
                    if (dic.CountGroups.ContainsKey(data.Key))
                    {
                        if (dic.CountGroups[data.Key] == Count[data.Key]) { flag = true; }
                        else { flag = false; break; }
                    }
                    else { flag = false; break; }
                }
            }
            else { flag = false; }
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void SortGroupsTest()
        {
            StatisticsMaster sm = new StatisticsMaster();
            Dic dic = new Dic();
            Assert.AreEqual(6, sm.SortGroups(dic.CountGroups, 6).Count);
        }

        [TestMethod]
        public void SortGroupsTest2()
        {
            StatisticsMaster sm = new StatisticsMaster();
            Dic dic = new Dic();
            Dictionary<String, int> result = sm.SortGroups(dic.CountGroups, 2);
            var first = result.Values.First();
            Assert.AreEqual(4, first);
        }

    }

    class Dic
    {
        public Dictionary<String, List<String>> GroupList;
        public Dictionary<String, int> CountGroups;

        public Dic()
        {
            GroupList = new Dictionary<String, List<String>>(){
                {"-1", new List<String>(){"5","2","3","4"}},
                {"-2", new List<String>(){"5","6","7","8"}},
                {"-3", new List<String>(){"8","2","3","5"}},
                {"-4", new List<String>(){"1","5","9","8"}}

            };

            CountGroups = new Dictionary<String, int>(){
                {"5", 4},
                {"2", 2},
                {"3", 2},
                {"4", 1},
                {"6", 1},
                {"7", 1},
                {"8", 3},
                {"1", 1},
                {"9", 1}
            };
        }
    }
}