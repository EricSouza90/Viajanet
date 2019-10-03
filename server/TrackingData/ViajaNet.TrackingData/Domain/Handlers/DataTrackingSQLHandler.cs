using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Domain.Commands;

namespace ViajaNet.TrackingData.Domain.Handlers
{
    public class DataTrackingSQLHandler : INotificationHandler<DataTrackingCreateCommand>
    {
        public Task Handle(DataTrackingCreateCommand notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
