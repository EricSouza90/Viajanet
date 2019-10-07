using Microsoft.EntityFrameworkCore;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Infrastructure.Mapping;

namespace ViajaNet.TrackingData.Infrastructure.Context
{
    public class ViajanetContext : DbContext, IUnitOfWork<ViajanetContext>
    {
        public ViajanetContext(DbContextOptions<ViajanetContext> context) : base(context) { }
        public int Commit() => SaveChanges();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DatatrackingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
