using Microsoft.EntityFrameworkCore;
using SampleUnitTesting.Domain;
using SampleUnitTesting.Infrastructure;

namespace SampleUnitTesting
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<SampleUnitTestingDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAttendantRepository, AttendantRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}