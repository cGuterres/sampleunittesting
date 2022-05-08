using Microsoft.EntityFrameworkCore;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public interface ISampleUnitTestingDbContext : IDisposable
{
    DbSet<T> GetDbSet<T>() where T : class;
}

public sealed class SampleUnitTestingDbContext : DbContext, ISampleUnitTestingDbContext
{
    public SampleUnitTestingDbContext(DbContextOptions<SampleUnitTestingDbContext> options) : base(options)
    {
    }

    public DbSet<Attendant>? Attendants { get; set; }
    public DbSet<Customer>? Customers { get; set; }

    public DbSet<T> GetDbSet<T>() where T : class
    {
        return Set<T>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AttendantConfiguration().Configure(modelBuilder.Entity<Attendant>());
        new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());

        base.OnModelCreating(modelBuilder);
    }
}
