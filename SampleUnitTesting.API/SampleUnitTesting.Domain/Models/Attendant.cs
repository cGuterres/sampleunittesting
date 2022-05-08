namespace SampleUnitTesting.Domain;

public sealed class Attendant
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    //public IEnumerable<CustomerAttendant> CustomerAttendants { get; set; } = Enumerable.Empty<CustomerAttendant>();
}
