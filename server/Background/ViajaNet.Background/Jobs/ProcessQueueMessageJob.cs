using MediatR;
using Quartz;
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
            var messages = await _mediator.Send(new DataTrackingReadQueueQuery());

            if (messages != null && messages.Count > 0)
                await _mediator.Publish(new DataTrackingCreateCommand(messages));
        }
    }
}
