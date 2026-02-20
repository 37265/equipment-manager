using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Configurations;

public class BookingEntityTypeConfiguration() : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        #region Update/Delete Behaviour
        builder
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => new { b.UserID }) // Example of how you would define a composite FK
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder
            .HasOne(b => b.Product)
            .WithMany(p => p.Bookings)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder
            .HasOne(b => b.Unit)
            .WithMany(u => u.Bookings)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder
            .HasOne(b => b.ApprovedByUser)
            .WithMany(u => u.ApprovedBookings)
            .HasForeignKey(b => b.ApprovedByUserID) // Example of a simple foreign key
            .OnDelete(DeleteBehavior.ClientNoAction);
        #endregion
    }
}