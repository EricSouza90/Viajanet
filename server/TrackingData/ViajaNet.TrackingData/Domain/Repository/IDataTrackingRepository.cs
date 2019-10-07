using System.Collections.Generic;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Repository
{
    public interface IDataTrackingRepository
    {
        void Save(DataTracking dataTracking);
        IList<DataTracking> Get(string ip, string pageName);
    }
}
