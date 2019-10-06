using MediatR;
using Quartz;
using System;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Domain.Commands;
using ViajaNet.TrackingData.Domain.Queries;

namespace ViajaNet.Background.Jobs
{
    [DisallowConcurrentExecution]
    public class ProcessQueueMessageJob : IJob
    {
        private readonly IMediator _mediator;

        public ProcessQueueMessageJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _mediator.Send(new DataTrackingAddQueueCommand(null));
            var messages = await _mediator.Send(new DataTrackingReadQueueQuery());

            await _mediator.Publish(new DataTrackingCreateCommand(messages));
        }
    }
}
