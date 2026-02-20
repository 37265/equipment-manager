using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Configurations;

public class MaintenanceEntityTypeConfiguration() : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder
            .Property(m => m.CreatedAt)
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        #region Delete/Update Behaviour
        builder
            .HasOne(m => m.CreatedByUser)
            .WithMany(u => u.CreatedMaintenances)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder
            .HasOne(m => m.ClosedByUser)
            .WithMany(u => u.ClosedMaintenances)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(m => m.Unit)
            .WithMany(u => u.Maintenances)
            .OnDelete(DeleteBehavior.NoAction);
        #endregion
    }
}