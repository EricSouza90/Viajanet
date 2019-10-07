using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViajaNet.TrackingData.Domain.Entities;

namespace ViajaNet.TrackingData.Infrastructure.Mapping
{
    public class DatatrackingMap : IEntityTypeConfiguration<DataTracking>
    {
        public void Configure(EntityTypeBuilder<DataTracking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.IP);
            builder.Property(i => i.PageName);
            builder.Property(i => i.PageParameters);
            builder.Property(i => i.Browser);
        }
    }
}
