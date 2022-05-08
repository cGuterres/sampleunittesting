namespace SampleUnitTesting.Domain;

public sealed class AttendantCustomer
{
    public int AttendantId { get; set; }
    public Attendant? Attendant { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
