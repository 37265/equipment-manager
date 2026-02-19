using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data;

public class EquipmentBookingContext : DbContext
{
    public EquipmentBookingContext(DbContextOptions<EquipmentBookingContext> options) : base(options)
    {
        
    }

    public EquipmentBookingContext()
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    /*
    - ClientSetNull     0 	Sets foreign key values to null as appropriate when changes are made to tracked entities and creates a non-cascading foreign key constraint in the database. This is the default for optional relationships.
    - Restrict          1   Sets foreign key values to null as appropriate when changes are made to tracked entities and creates a non-cascading foreign key constraint in the database.
    - SetNull           2   Sets foreign key values to null as appropriate when changes are made to tracked entities and creates a foreign key constraint in the database that propagates null values from principals to dependents.
    - Cascade 	        3   Automatically deletes dependent entities when the principal is deleted or the relationship to the principal is severed, and creates a foreign key constraint in the database with cascading deletes enabled. This is the default for required relationships.
    - ClientCascade     4   Automatically deletes dependent entities when the principal is deleted or the relationship to the principal is severed, but creates a non-cascading foreign key constraint in the database.
    - NoAction  	    5   Sets foreign key values to null as appropriate when changes are made to tracked entities and creates a non-cascading foreign key constraint in the database.
    - ClientNoAction 	6   Tracked dependents are not deleted and their foreign key values are not set to null when deleting principal entities. A non-cascading foreign key constraint is created in the database.   
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        // TODO move all of this to the entity configuration classes
        // ----------------- User table --------------------
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(Role.User);
        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
        // FIXME The SYSDATETIMEOFFSET() default value is not accepted when trying to create a migration 
        // modelBuilder.Entity<User>()
        //     .Property(u => u.CreatedAt)
        //     // SQL Server implementation
        //     .HasDefaultValue("SYSDATETIMEOFFSET()");
        //     // PostgreSQL implementation (for later)
        //     // .HasDefaultValue("CURRENT_TIMESTAMP");
        //////////////////////////////////////////////////////////////////////////////////////
        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedMaintenances)
            .WithOne(m => m.CreatedByUser)
            .OnDelete(DeleteBehavior.ClientNoAction);
        modelBuilder.Entity<User>()
            .HasMany(u => u.ClosedMaintenances)
            .WithOne(m => m.ClosedByUser)
            .OnDelete(DeleteBehavior.ClientNoAction);

        // ----------------- Booking --------------------
        modelBuilder.Entity<Booking>()
            .Property(b => b.Status)
            .HasDefaultValue(BookingStatus.Pending);        
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.ApprovedByUser)
            .WithMany(u => u.ApprovedBookings)
            .HasForeignKey(b => b.ApprovedByUserID) // Example of a simple foreign key 
            .OnDelete(DeleteBehavior.ClientNoAction);
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => new { b.UserID }) // Example of how you would define a composite FK
            .OnDelete(DeleteBehavior.ClientNoAction);
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Unit)
            .WithMany(u => u.Bookings)
            .OnDelete(DeleteBehavior.ClientNoAction);

        // ----------------- Product --------------------

    }
}
