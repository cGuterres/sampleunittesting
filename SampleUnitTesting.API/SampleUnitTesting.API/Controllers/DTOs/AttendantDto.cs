namespace SampleUnitTesting.API.Controllers;

public sealed class AttendantDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public bool IsActive { get; set; }
    public ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
}
