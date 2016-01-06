using CreateUser.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xstream.Core;


using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;
using System.IO;
using System.Xml.Serialization;
using CreateUser.Api;
using CreateUser.Masters;
using CreateUser.Mappers;

namespace CreateUser
{
    class Program
    {
        public static void CreateUser(IApi Api, UserToCreate user)
        {
            InternetToDataBase idb = new InternetToDataBase(user, Api);

            Console.WriteLine("Регистрация пользователя и заполнение базы данных...");

            idb.InsertToUsers();

            idb.InsertToListFriends();

            idb.InsertToGroup();

            UserMapper userMapper = new UserMapper();
            userMapper.Update(user);

            Console.WriteLine("Регистрация завершена!!!");
        }



        static void Main(string[] args)
        {
            Consumer c = new Consumer();
            String xml = c.Receive("ToCreate");

            var stringReader = new System.IO.StringReader(xml);
            var serializerr = new XmlSerializer(typeof(UserToCreate));
            UserToCreate user = serializerr.Deserialize(stringReader) as UserToCreate;

            IApi Api = new VKClient();
            CreateUser(Api, user);
        }
    }
}
