using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Domain.Commands;
using ViajaNet.TrackingData.Domain.Repository;

namespace ViajaNet.TrackingData.Domain.Handlers
{
    public class DataTrackingSQLHandler : INotificationHandler<DataTrackingCreateCommand>
    {
        private readonly IDataTrackingSQLRepository _dataTrackingSQLRepository;

        public DataTrackingSQLHandler(IDataTrackingSQLRepository dataTrackingSQLRepository)
        {
            _dataTrackingSQLRepository = dataTrackingSQLRepository;
        }

        public Task Handle(DataTrackingCreateCommand notification, CancellationToken cancellationToken)
        {
            notification.DataTrackingList.ForEach(item =>
            {
                _dataTrackingSQLRepository.Save(item);
            });

            return Task.CompletedTask;
        }
    }
}
