using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public sealed class CustomerAttendantConfiguration : IEntityTypeConfiguration<CustomerAttendant>
{
    public void Configure(EntityTypeBuilder<CustomerAttendant> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("CustomerAttendants", "SampleUnitTesting");

        builder.HasKey(x => new { x.CustomerId, x.AttendantId });

        builder.Property(x => x.AttendantId).IsRequired().HasColumnType("int");
        builder.Property(x => x.CustomerId).IsRequired().HasColumnType("int");

        builder
            .HasOne(x => x.Attendant)
            .WithMany(cust => cust.Customers)
            .HasForeignKey(x => x.AttendantId);

        builder
            .HasOne(x => x.Customer)
            .WithMany(att => att.Attendants)
            .HasForeignKey(x => x.CustomerId);
               
    }
}
