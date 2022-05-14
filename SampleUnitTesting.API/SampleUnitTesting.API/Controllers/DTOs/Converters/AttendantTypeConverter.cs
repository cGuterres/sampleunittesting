using SampleUnitTesting.Domain;
using System.ComponentModel;
using System.Globalization;

namespace SampleUnitTesting.API.Controllers;

public sealed class AttendantTypeConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(AttendantDto);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        var attendant = value as Attendant;

        if (attendant is null) return null;


        return new AttendantDto
        {
            Id = attendant.Id,
            FullName = $"{attendant.FirstName} {attendant.LastName}",
            IsActive = attendant.IsActive,
            Customers = attendant.Customers.Select(x => new CustomerDto
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                IsActive = x.IsActive
            }).ToList()
        };
    }
}
