using Microsoft.EntityFrameworkCore;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Infrastructure.Context;

namespace ViajaNet.TrackingData.Infrastructure.Repository.Base
{
    public abstract class BaseViajaNetRepository<T> where T : class
    {
        protected readonly IUnitOfWork<ViajanetContext> _context;
        protected readonly DbSet<T> _dbSet;

        public BaseViajaNetRepository(IUnitOfWork<ViajanetContext> context)
        {
            _context = context;
            _dbSet = (context as DbContext).Set<T>();
        }
    }
}
