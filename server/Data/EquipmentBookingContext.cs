using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data;

public class EquipmentBookingContext : DbContext
{
    public EquipmentBookingContext(DbContextOptions<EquipmentBookingContext> options) : base(options)
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
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Unit>().ToTable("Unit");
        modelBuilder.Entity<Maintenance>().ToTable("Maintenance");
        modelBuilder.Entity<Booking>().ToTable("Booking");
    }
}