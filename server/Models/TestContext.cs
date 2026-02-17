using Microsoft.EntityFrameworkCore;

namespace server.Models;

/**
* The database context coordinates EF functionality for a data model. 
*/
public class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public DbSet<Test> Tests { get; set; } = null!;
}