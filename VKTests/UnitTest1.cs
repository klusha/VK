using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VK;

namespace VKTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IDUserTest()
        {
            Assert.AreEqual("id25293291", VK.VKClient.IDUser("https://vk.com/id25293291"));
        }

        [TestMethod]
        public void GetIdTest()
        {
            Assert.AreEqual("25293291", VK.VKClient.GetId("https://vk.com/id25293291"));
        }

        [TestMethod]
        public void FriendsListTest()
        {
            Assert.AreEqual(123, VK.VKClient.FriendsList("25293291").Count);
        }

        [TestMethod]
        public void GroupsListTest()
        {
            Assert.AreEqual(5, VK.VKClient.GroupsList("195116826").Count);
        }

        [TestMethod]
        public void PageDataTest()
        {
            Assert.AreEqual("{\"response\":[{\"uid\":25293291,\"first_name\":\"Анастасия\",\"last_name\":\"Афанасьева\",\"hidden\":1}]}", VK.HTTPMaster.PageData("getProfiles", "uids=25293291"));
        }

        [TestMethod]
        public void GetNameGroupTest()
        {
            Assert.AreEqual("Пикабу", VK.StatisticsMaster.GetNameGroup("pikabu"));
        }

    }
}