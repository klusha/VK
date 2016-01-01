using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;

namespace Update
{
    class Producer
    {
        private Uri connecturi;
        private IConnectionFactory factory;
        IDestination destination;

        public Producer()
        {
            connecturi = new Uri("activemq:tcp://localhost:61616");
            Console.WriteLine("About to connect to " + connecturi);
            factory = new NMSConnectionFactory(connecturi);
            
        }

        public void SendMessage(String message, String queueName)
        {
            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                destination = SessionUtil.GetDestination(session, "queue://" + queueName);
                Console.WriteLine("Using destination: " + destination);
                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();

                    // Send a message
                    ITextMessage request = session.CreateTextMessage(message);

                    producer.Send(request);
                }
            }
        }
    }
}
