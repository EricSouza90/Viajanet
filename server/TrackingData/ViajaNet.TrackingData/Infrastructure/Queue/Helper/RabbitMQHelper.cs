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
                CreateQueue(queueName, channel);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) => { messageList.Add(Encoding.UTF8.GetString(ea.Body)); };

                channel.BasicConsume(queue: queueName,
                     autoAck: true,
                     consumer: consumer);
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
