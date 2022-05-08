using Microsoft.EntityFrameworkCore;
using SampleUnitTesting.Domain;
using SampleUnitTesting.Infrastructure;

namespace SampleUnitTesting
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ISampleUnitTestingDbContext, SampleUnitTestingDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAttendantRepository, AttendantRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}