using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Diagnostics;

using VK;
using VK.Entity;
using VK.Mappers;
using VK.Masters;
using VK.Api;

namespace VK
{
    class VKProg
    {
        public static void CreateUser(IApi Api)
        {
            InternetToDataBase idb = new InternetToDataBase("https://vk.com/id25293291", Api);
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Регистрация пользователя и заполнение базы данных...");
            stopWatch.Start();
            idb.InsertToUsers();
            stopWatch.Stop();
            TimeSpan insertUser = stopWatch.Elapsed;

            stopWatch.Start();
            idb.InsertToListFriends();
            stopWatch.Stop();
            TimeSpan insertListFriends = stopWatch.Elapsed;

            stopWatch.Start();
            idb.InsertToGroup();
            stopWatch.Stop();
            TimeSpan insertGroup = stopWatch.Elapsed;

            string userTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            insertUser.Hours, insertUser.Minutes, insertUser.Seconds, insertUser.Milliseconds / 10);
            Console.WriteLine("userTime " + userTime);

            string ListFriendsTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            insertListFriends.Hours, insertListFriends.Minutes, insertListFriends.Seconds, insertListFriends.Milliseconds / 10);
            Console.WriteLine("ListFriendsTime " + ListFriendsTime);

            string GroupTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            insertGroup.Hours, insertGroup.Minutes, insertGroup.Seconds, insertGroup.Milliseconds / 10);
            Console.WriteLine("GroupTime " + GroupTime);

            idb.InsertToGroup();
            Console.WriteLine("Завершение регистрации!!!");
        }

        public static void Update(User user, IApi Api)
        {
            Top top = new Top(Api);
            Console.WriteLine("Ежедневное обновление запущено...");
            UpdateMaster updateMaster = new UpdateMaster(user, Api);
            updateMaster.Update();

            top.CurrentListFriends(user);
            top.CreateTop(user);
            Console.WriteLine("Ежедневное обновление завершено!!!");
        }

        static void Main(string[] args)
        {
            //VKClient vkClient = new VKClient();
            IApi vkClient = new VKClient();
            //Top top = new Top();
            
            

            UserMapper userMapper = new UserMapper();
            
            User user = userMapper.FindByVkId(vkClient.GetId("https://vk.com/id252932912"));

            //top.CurrentListFriends(user);


            int action = 2;
            Top top = new Top(vkClient);
            switch (action)
            {
                case 1:     // InternetToDataBase
                    {
                        CreateUser(vkClient);
                        break;
                    }
                case 2:     // Ежедневное обновление БД
                    {
                        Update(user, vkClient);
                        break;
                    }
                case 3:     // Получение топа на текущюю дату
                    {
                        DateTime date1 = DateTime.Today;
                        Tops tops = new Tops();
                        tops = top.FindTop(date1); // ID групп заменить на названия
                        break;
                    }
            }



            


            //DateTime date1 = DateTime.Today;
            //Console.WriteLine(date1.ToString("dd.MM.yyyy"));

            //Dictionary<int, int> a = new Dictionary<int, int>();
            //a.Add(45, 12);
            //a.Add(46, 31);


            //Tops tops = new Tops(a);
            //TopsMapper topsMapper = new TopsMapper();
            //topsMapper.FindByDate(date1.ToString("dd.MM.yyyy"));

            Console.ReadKey();
        }
    }
}
