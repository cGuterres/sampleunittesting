using SampleUnitTesting.API.Controllers;
using SampleUnitTesting.Domain;
using System.ComponentModel;

namespace SampleUnitTesting.API.CrossCutting;

public static class CustomConverter
{
    public static void ConvertTypes()
    {
        TypeDescriptor.AddAttributes(typeof(Attendant), new TypeConverterAttribute(typeof(AttendantTypeConverter)));
        TypeDescriptor.AddAttributes(typeof(Customer), new TypeConverterAttribute(typeof(CustomerTypeConverter)));
    }
}
