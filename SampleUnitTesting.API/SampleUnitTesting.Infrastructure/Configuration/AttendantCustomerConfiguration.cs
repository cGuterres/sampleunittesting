using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public sealed class AttendantCustomerConfiguration : IEntityTypeConfiguration<AttendantCustomer>
{
    public void Configure(EntityTypeBuilder<AttendantCustomer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("AttendantCustomer");

        builder.HasKey(x => new { x.AttendantId, x.CustomerId });

        builder.Property(x => x.AttendantId).IsRequired().HasColumnType("int");
        builder.Property(x => x.CustomerId).IsRequired().HasColumnType("int");

        builder.HasOne(p => p.Attendant)
               .WithMany(p => p.AttendantCustomers)
               .HasForeignKey(x => x.AttendantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Customer)
               .WithMany(p => p.AttendantCustomers)
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
