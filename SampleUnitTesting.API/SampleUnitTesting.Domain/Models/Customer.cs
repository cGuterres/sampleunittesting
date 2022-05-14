namespace SampleUnitTesting.Domain;

public record Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public ICollection<Attendant> Attendants { get; set; } = new List<Attendant>();
}
