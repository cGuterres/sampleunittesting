using Nelibur.ObjectMapper;
using SampleUnitTesting.API.Controllers;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.API.CrossCutting
{
    public static class AddTinyMapper
    {
        public static void ConfigureTinyMapper()
        {
            TinyMapper.Bind<Attendant, AttendantDto>(config =>
            {
                config.Ignore(x => x.CreatedOn);
                config.Ignore(x => x.UpdatedOn);

                config.Bind(source => source.Id, dest => dest.Id);
                config.Bind(source => source.FirstName, dest => dest.FullName);
                config.Bind(source => source.IsActive, dest => dest.IsActive);
                config.Bind(source => source.Customers, dest => dest.Customers);
            });

            TinyMapper.Bind<Customer, CustomerDto>(config =>
            {
                config.Ignore(x => x.CreatedOn);
                config.Ignore(x => x.UpdatedOn);

                config.Bind(source => source.Id, dest => dest.Id);
                config.Bind(source => source.FirstName, dest => dest.FullName);
                config.Bind(source => source.IsActive, dest => dest.IsActive);
            });
        }
    }
}
