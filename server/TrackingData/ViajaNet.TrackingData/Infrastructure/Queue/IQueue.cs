using RabbitMQ.Client;
using System.Collections.Generic;

namespace ViajaNet.TrackingData.Infrastructure.Queue
{
    public interface IQueue
    {
        ConnectionFactory GetConnectionFactory();
        IConnection CreateConnection(ConnectionFactory connectionFactory);
        IList<string> RetrieveMessageList(string queueName, IConnection connection);
        void WriteMessageOnQueue(string message, string queueName, IConnection connection);
    }
}
