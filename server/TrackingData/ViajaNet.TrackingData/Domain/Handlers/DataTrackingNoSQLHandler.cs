using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Domain.Commands;
using ViajaNet.TrackingData.Domain.Entities;
using ViajaNet.TrackingData.Domain.Queries;

namespace ViajaNet.TrackingData.Domain.Handlers
{
    public class DataTrackingNoSQLHandler : INotificationHandler<DataTrackingCreateCommand>, IRequestHandler<DataTrackingQuery, IList<DataTracking>>
    {
        public Task Handle(DataTrackingCreateCommand notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IList<DataTracking>> Handle(DataTrackingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
