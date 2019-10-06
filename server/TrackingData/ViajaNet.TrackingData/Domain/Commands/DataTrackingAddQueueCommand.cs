using MediatR;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Commands
{
    public class DataTrackingAddQueueCommand : IRequest
    {
        public DataTracking DataTracking { get; private set; }

        public DataTrackingAddQueueCommand(DataTracking dataTracking)
        {
            this.DataTracking = dataTracking;
        }
    }
}
