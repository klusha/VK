using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;

namespace Server
{
    class Consumer
    {
        private Uri connecturi;
        private IConnectionFactory factory;
        IDestination destination;

        public Consumer()
        {
            connecturi = new Uri("activemq:tcp://localhost:61616");
            Console.WriteLine("About to connect to " + connecturi);
            factory = new NMSConnectionFactory(connecturi);
            
        }

        public String Receive(String queueName)
        {
            String message = "";
            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                destination = SessionUtil.GetDestination(session, "queue://" + queueName);
                Console.WriteLine("Using destination: " + destination);
                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();

                    ITextMessage textMessage = consumer.Receive() as ITextMessage;
                    if (textMessage == null)
                    {
                        Console.WriteLine("No message received!");
                    }
                    else
                    {
                        message = textMessage.Text;
                    }
                }
            }
            return message;
        }
    }
}
