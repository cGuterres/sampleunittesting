namespace SampleUnitTesting.Domain;

public interface IAttendantRepository
{
    Task<IEnumerable<Attendant>> GetAllAsync();
}
