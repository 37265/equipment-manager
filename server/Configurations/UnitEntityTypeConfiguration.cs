using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Configurations;

public class UnitEntityTypeConfiguration() : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder
            .HasOne(u => u.Product)
            .WithMany(p => p.Units)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasIndex(u => u.SerialNumber)
            .IsUnique();
        
        builder
            .HasIndex(u => u.Tag)
            .IsUnique();
    }
}