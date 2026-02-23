using server.Models;
using Microsoft.EntityFrameworkCore;
using server.Configurations;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Applies configuration from all IEntityTypeConfiguration<TEntity> instances that are defined in provided assembly. (Microsoft docs)
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EquipmentBookingContext).Assembly);
    }
}
