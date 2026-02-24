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

        modelBuilder.Entity<Category>()
            .HasData(
                new Category { ID = 1, Name = "Laptops", Description = "" },
                new Category { ID = 2, Name = "Phones", Description = "" },
                new Category { ID = 3, Name = "Storage", Description = "" }
            );

        modelBuilder.Entity<Product>()
            .HasData(
                new Product { ID = 1, Brand = "Lenovo", Model = "ThinkPad L15", Description = "",
                            ImageUrl = "", CategoryID = 1},
                new Product { ID = 2, Brand = "Apple", Model = "MacBook Pro", Description = "",
                            ImageUrl = "", CategoryID = 1},
                new Product { ID = 3, Brand = "Dell", Model = "Inspiron", Description = "",
                            ImageUrl = "", CategoryID = 1}
            );

        modelBuilder.Entity<User>()
            .HasData(
                new User { ID = 1, Email = "test@mail.com", Password = "Password1!", 
                            FirstName = "Test", LastName = "Guy" }
            );
    }
}
