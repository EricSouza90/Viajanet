using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Domain.Entities;
using ViajaNet.TrackingData.Domain.Repository;
using ViajaNet.TrackingData.Infrastructure.Context;
using ViajaNet.TrackingData.Infrastructure.Repository.Base;

namespace ViajaNet.TrackingData.Infrastructure.Repository
{
    public class DataTrackingSQLRepository : BaseViajaNetRepository<DataTracking>, IDataTrackingSQLRepository
    {
        public DataTrackingSQLRepository(IUnitOfWork<ViajanetContext> context) : base(context)
        {
        }

        public void Save(DataTracking dataTracking)
        {
            _dbSet.Add(dataTracking);
            _context.Commit();
        }
    }
}
