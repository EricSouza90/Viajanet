using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Domain.Repository
{
    public interface IDataTrackingSQLRepository
    {
        void Save(DataTracking dataTracking);
    }
}
