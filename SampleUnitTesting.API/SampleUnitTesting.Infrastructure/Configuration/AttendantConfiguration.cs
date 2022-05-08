using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public sealed class AttendantConfiguration : IEntityTypeConfiguration<Attendant>
{
    public void Configure(EntityTypeBuilder<Attendant> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Attendants");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired().HasColumnType("int");
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100).HasColumnType("varchar");
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100).HasColumnType("varchar");
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnType("bit");
        builder.Property(x => x.CreatedOn).ValueGeneratedOnAddOrUpdate().HasDefaultValue(DateTime.UtcNow).HasColumnType("datetime");
        builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate().HasDefaultValue(DateTime.UtcNow).HasColumnType("datetime");
    }
}
