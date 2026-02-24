using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Configurations;

public class UserEntityTypeConfiguration() : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Default Values
        builder
            .Property(u => u.CreatedAt)
            // SQL Server implementation
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");
            // PostgreSQL implementation (for later)
            // .HasDefaultValue("CURRENT_TIMESTAMP");
        #endregion

        builder
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}