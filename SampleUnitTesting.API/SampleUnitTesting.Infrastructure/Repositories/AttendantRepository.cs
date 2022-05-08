using Microsoft.EntityFrameworkCore;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Infrastructure;

public sealed class AttendantRepository : IAttendantRepository
{
    private readonly ISampleUnitTestingDbContext _context;

    public AttendantRepository(ISampleUnitTestingDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        _context = context;
    }

    public async Task<IEnumerable<Attendant>> GetAllAsync()
    {
        return await _context.GetDbSet<Attendant>()
                             .Include(x => x.Customers)
                             .ToListAsync();
    }
}
