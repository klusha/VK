using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using VK;
using VK.Masters;
using VK.Api;
using VK.Entity;
using System.Linq;
using Moq;

//using NUnit.Framework;


namespace VKTests
{
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

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void IDUserTest()
        {
            IApi vkClient = new VKClient();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("id25293291", vkClient.IDUser("https://vk.com/id25293291"));
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void SortGroupsTest()
        {
            StatisticsMaster sm = new StatisticsMaster();
            Dic dic = new Dic();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(6, sm.SortGroups(dic.CountGroups, 6).Count);
        }

        [TestMethod]
        public void SortGroupsTest2()
        {
            StatisticsMaster sm = new StatisticsMaster();
            Dic dic = new Dic();
            Dictionary<String, int> result = sm.SortGroups(dic.CountGroups, 2);
            var first = result.Values.First();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(4, first);
        }

    }


    [TestClass]
    public class MockTest
    {

        [TestMethod]
        public void GetNameMockTest()
        {
            List<String> name = new List<String>();
            name.Add("Афанасьева");
            name.Add("Анастасия");
 
            var mock = new Mock<IApi>();
            mock.Setup(a => a.GetName("https://vk.com/id25293291")).Returns(name);
            List<String> nameTest = mock.Object.GetName("https://vk.com/id25293291");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(name, nameTest);
        }

        [TestMethod]
        public void GetIdMockTest()
        {
            String Id = "25293291";

            var mock = new Mock<IApi>();
            mock.Setup(a => a.GetId("https://vk.com/id25293291")).Returns(Id);
            String IdTest = mock.Object.GetId("https://vk.com/id25293291");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Id, IdTest);
        }

        [TestMethod]
        public void FriendsListMockTest()
        {
            List<String> ListFriends = new List<String>();
            ListFriends.Add("25293291");
            ListFriends.Add("52506062");
            ListFriends.Add("78543368");
            ListFriends.Add("260871398");

            var mock = new Mock<IApi>();
            mock.Setup(a => a.FriendsList("https://vk.com/id142182681")).Returns(ListFriends);
            List<String> ListFriendsTest = mock.Object.FriendsList("https://vk.com/id142182681");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ListFriends, ListFriendsTest);
        }

    }


    [TestClass]
    public class NegativeTest
    {
        [TestMethod]
        public void UpdateNegativeTest()
        {
            User user = null;
            IApi Api = new VKClient();
            UpdateMaster updateMaster = new UpdateMaster(user, Api);

            NUnit.Framework.Assert.Throws<Exception>(() => updateMaster.Update());
        }
    }


}