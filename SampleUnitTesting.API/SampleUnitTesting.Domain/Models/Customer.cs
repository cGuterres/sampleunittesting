namespace SampleUnitTesting.Domain;

public sealed class Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public IEnumerable<CustomerAttendant> Attendants { get; set; } = Enumerable.Empty<CustomerAttendant>();
}
