using MediatR;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Domain.Commands;
using ViajaNet.TrackingData.Domain.Entities;
using ViajaNet.TrackingData.Domain.Queries;
using ViajaNet.TrackingData.Domain.Repository;

namespace ViajaNet.TrackingData.Domain.Handlers
{
    public class QueueHandler : IRequestHandler<DataTrackingAddQueueCommand>, IRequestHandler<DataTrackingReadQueueQuery, IList<DataTracking>>
    {
        private readonly IQueueRepository _queueRepository;
        private readonly RabbitMQConfiguration _queueConfiguration;
        public QueueHandler(IQueueRepository queueRepository, IOptions<RabbitMQConfiguration> options)
        {
            _queueRepository = queueRepository;
            _queueConfiguration = options.Value;
        }

        public Task<Unit> Handle(DataTrackingAddQueueCommand request, CancellationToken cancellationToken)
        {
            _queueRepository.SendMessage(request.DataTracking, _queueConfiguration.QueueName);
            return Unit.Task;
        }

        public async Task<IList<DataTracking>> Handle(DataTrackingReadQueueQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_queueRepository.ReadMessages<DataTracking>(_queueConfiguration.QueueName));

        }
    }
}
