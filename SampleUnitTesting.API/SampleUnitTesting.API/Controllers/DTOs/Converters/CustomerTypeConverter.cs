using SampleUnitTesting.Domain;
using System.ComponentModel;
using System.Globalization;

namespace SampleUnitTesting.API.Controllers;

public class CustomerTypeConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(CustomerDto);
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        var customer = value as Customer;

        if (customer is null) return null;

        return new CustomerDto
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            IsActive = customer.IsActive
        };
    }
}
