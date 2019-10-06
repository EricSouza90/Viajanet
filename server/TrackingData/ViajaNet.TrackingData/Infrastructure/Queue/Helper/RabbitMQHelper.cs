using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text;
using ViajaNet.TrackingData.Common;

namespace ViajaNet.TrackingData.Infrastructure.Queue.Helper
{
    public class RabbitMQHelper : IQueue
    {
        private readonly RabbitMQConfiguration _queueConfiguration;
        public RabbitMQHelper(IOptions<RabbitMQConfiguration> options)
        {
            _queueConfiguration = options.Value;
        }
        public IConnection CreateConnection(ConnectionFactory connectionFactory) => connectionFactory.CreateConnection();
        public ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = _queueConfiguration.HostName,
                Port = _queueConfiguration.Port.ToInt32(),
                UserName = _queueConfiguration.UserName,
                Password = _queueConfiguration.Password
            };
        }
        private QueueDeclareOk CreateQueue(string queueName, IModel connection) => connection.QueueDeclare(queueName, false, false, false, null);
        public IList<string> RetrieveMessageList(string queueName, IConnection connection)
        {
            var messageList = new List<string>();

            using (var channel = connection.CreateModel())
            {
                var queueDeclare = CreateQueue(queueName, channel);
                var consumer = new QueueingBasicConsumer(channel);

                const bool autoAck = false;
                channel.BasicConsume(queueName, autoAck, consumer);

                for (int i = 0; i < queueDeclare.MessageCount; i++)
                {
                    var dequeue = consumer.Queue.Dequeue();

                    var body = dequeue.Body;
                    var message = Encoding.UTF8.GetString(body);

                    messageList.Add(message);
                    channel.BasicAck(dequeue.DeliveryTag, false);
                }
            }

            return messageList;
        }
        public void WriteMessageOnQueue(string message, string queueName, IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                CreateQueue(queueName, channel);
                channel.BasicPublish(string.Empty, queueName, null, Encoding.ASCII.GetBytes(message));
            }
        }

    }
}
