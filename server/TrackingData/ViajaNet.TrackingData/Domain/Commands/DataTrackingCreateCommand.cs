using MediatR;
using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Commands
{
    public class DataTrackingCreateCommand : INotification
    {
        public IList<DataTracking> DataTrackingList { get; }
        public DataTrackingCreateCommand(IList<DataTracking> dataTrackingList)
        {
            DataTrackingList = dataTrackingList;
        }
    }
}
