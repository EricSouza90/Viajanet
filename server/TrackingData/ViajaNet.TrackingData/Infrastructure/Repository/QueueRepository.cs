using Microsoft.Extensions.Options;
using System.Collections.Generic;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Domain.Repository;
using ViajaNet.TrackingData.Infrastructure.Queue;

namespace ViajaNet.TrackingData.Infrastructure.Repository
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IQueue _queue;
       
        public QueueRepository(IQueue queue)
        {
            _queue = queue;
        }

        public IList<T> ReadMessages<T>(string queue)
        {
            var connectionFactory = _queue.GetConnectionFactory();
            var connection = _queue.CreateConnection(connectionFactory);

            var messages = _queue.RetrieveMessageList(queue, connection);

            var returnMessages = new List<T>();

            messages.ForEach(m =>
            {
                var message = m.FromJson<T>();
                returnMessages.Add(message);
            });

            return returnMessages;
        }

        public void SendMessage<T>(T message, string queue)
        {
            var connectionFactory = _queue.GetConnectionFactory();
            var connection = _queue.CreateConnection(connectionFactory);

            _queue.WriteMessageOnQueue(message.ToJson(), queue, connection);
        }
    }
}
