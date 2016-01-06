using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ.Commands;

namespace Server
{
    class QueueReceiver : IMessageConsumer
    {
        public event MessageListener OnMessageReceived;
        private readonly ISession session;
        private readonly String Destination;
        private readonly IQueue queue;
        private bool disposed;

        public QueueReceiver(ISession session, String destination)
        {
            this.session = session;
            this.Destination = destination;
            queue = new ActiveMQQueue(Destination);
        }

        public IMessageConsumer Consumer { get; private set; }

        public String ConsumerId { get; private set; }

        public void Start(String consumerId)
        {
            Consumer = session.CreateConsumer(queue);
            Consumer.Listener += (message =>
                {
                    var textMessage = message as ITextMessage;
                    if (textMessage == null) throw new InvalidCastException();
                    if (OnMessageReceived != null)
                    {
                        OnMessageReceived(textMessage);
                    }
                });
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Consumer.Dispose();
                disposed = true;
            }
        }


        public void Close()
        {
            throw new NotImplementedException();
        }

        public ConsumerTransformerDelegate ConsumerTransformer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event MessageListener Listener;

        public IMessage Receive(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public IMessage Receive()
        {
            throw new NotImplementedException();
        }

        public IMessage ReceiveNoWait()
        {
            throw new NotImplementedException();
        }
    }
}
