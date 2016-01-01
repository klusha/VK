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
    class QueueSender : IMessageProducer
    {

        private bool dispose;
        private readonly IQueue queue;
        private readonly ISession session;

        public QueueSender(ISession session, String destination)
        {
            Dectinanion = destination;
            this.session = session;
            queue = new ActiveMQQueue(Dectinanion);
            Producer = this.session.CreateProducer(queue);
        }

        public IMessageProducer Producer { get; private set; }

        public String Dectinanion { get; private set; }

        public void SendMessage(String message)
        {
            Producer.Send(queue, message);
        }

        public void Dispose()
        {
            if (dispose) return;
            Producer.Dispose();
            dispose = true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IBytesMessage CreateBytesMessage(byte[] body)
        {
            throw new NotImplementedException();
        }

        public IBytesMessage CreateBytesMessage()
        {
            throw new NotImplementedException();
        }

        public IMapMessage CreateMapMessage()
        {
            throw new NotImplementedException();
        }

        public IMessage CreateMessage()
        {
            throw new NotImplementedException();
        }

        public IObjectMessage CreateObjectMessage(object body)
        {
            throw new NotImplementedException();
        }

        public IStreamMessage CreateStreamMessage()
        {
            throw new NotImplementedException();
        }

        public ITextMessage CreateTextMessage(string text)
        {
            throw new NotImplementedException();
        }

        public ITextMessage CreateTextMessage()
        {
            throw new NotImplementedException();
        }

        public MsgDeliveryMode DeliveryMode
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

        public bool DisableMessageID
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

        public bool DisableMessageTimestamp
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

        public MsgPriority Priority
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

        public ProducerTransformerDelegate ProducerTransformer
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

        public TimeSpan RequestTimeout
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

        public void Send(IDestination destination, IMessage message, MsgDeliveryMode deliveryMode, MsgPriority priority, TimeSpan timeToLive)
        {
            throw new NotImplementedException();
        }

        public void Send(IDestination destination, IMessage message)
        {
            throw new NotImplementedException();
        }

        public void Send(IMessage message, MsgDeliveryMode deliveryMode, MsgPriority priority, TimeSpan timeToLive)
        {
            throw new NotImplementedException();
        }

        public void Send(IMessage message)
        {
            throw new NotImplementedException();
        }

        public TimeSpan TimeToLive
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
    }
}
