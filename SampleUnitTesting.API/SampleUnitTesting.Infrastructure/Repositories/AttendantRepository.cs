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

    public async Task<IEnumerable<Attendant>> FindAllAsync()
    {
        return await _context.GetDbSet<Attendant>().ToListAsync();
    }

    public async Task<IEnumerable<Attendant>> FindAllWithCustomersAsync()
    {
        return await _context.GetDbSet<Attendant>()
                             .Include(x => x.Customers)
                             .ToListAsync();
    }

    public async Task<Attendant?> FindAsync(int id)
    {
        return await _context.GetDbSet<Attendant>()
                             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Attendant?> FindWithCustomersAsync(int id)
    {
        return await _context.GetDbSet<Attendant>()
                             .Include(x => x.Customers)
                             .FirstOrDefaultAsync(x => x.Id == id);
    }
}
