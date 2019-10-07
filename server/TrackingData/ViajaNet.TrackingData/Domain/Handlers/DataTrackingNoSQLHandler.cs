using MediatR;
using System;
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
    public class DataTrackingNoSQLHandler : INotificationHandler<DataTrackingCreateCommand>, IRequestHandler<DataTrackingQuery, IList<DataTracking>>
    {
        private readonly IDataTrackingRepository _dataTrackingRepository;
        public DataTrackingNoSQLHandler(IDataTrackingRepository dataTrackingRepository)
        {
            _dataTrackingRepository = dataTrackingRepository;
        }

        public Task Handle(DataTrackingCreateCommand notification, CancellationToken cancellationToken)
        {
            notification.DataTrackingList.ForEach(item =>
            {
                _dataTrackingRepository.Save(item);
            });

            return Task.CompletedTask;
        }

        public Task<IList<DataTracking>> Handle(DataTrackingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataTrackingRepository.Get(request.IP, request.PageName));
        }
    }
}
