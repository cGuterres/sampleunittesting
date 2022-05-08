namespace SampleUnitTesting.Domain;

public interface IAttendantRepository
{
    Task<IEnumerable<Attendant>> FindAllAsync();
    Task<IEnumerable<Attendant>> FindAllWithCustomersAsync();
    Task<Attendant?> FindAsync(int id);
    Task<Attendant?> FindWithCustomersAsync(int id);
}
