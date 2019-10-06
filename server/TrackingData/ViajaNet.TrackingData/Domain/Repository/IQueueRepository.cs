using System.Collections.Generic;

namespace ViajaNet.TrackingData.Domain.Repository
{
    public interface IQueueRepository
    {
        void SendMessage<T>(T message, string queue);
        IList<T> ReadMessages<T>(string queue);
    }
}
