using Microsoft.EntityFrameworkCore;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public interface ISampleUnitTestingDbContext
{

}

public sealed class SampleUnitTestingDbContext : DbContext, ISampleUnitTestingDbContext, IDisposable
{
    public SampleUnitTestingDbContext(DbContextOptions<SampleUnitTestingDbContext> options) : base(options)
    {
    }

    public DbSet<Attendant>? Attendants { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<CustomerAttendant>? CustomerAttendants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AttendantConfiguration().Configure(modelBuilder.Entity<Attendant>());
        new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        new CustomerAttendantConfiguration().Configure(modelBuilder.Entity<CustomerAttendant>());

        base.OnModelCreating(modelBuilder);
    }
}
