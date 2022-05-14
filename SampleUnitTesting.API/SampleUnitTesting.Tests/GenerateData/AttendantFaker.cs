using Bogus;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Tests;

public static class AttendantFaker
{
    public static IEnumerable<Attendant> Generate(int quantity)
    {
        return new Faker<Attendant>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.IsActive, f => true)
            .Generate(quantity);
    }

    public static IEnumerable<Attendant> GenerateWithClients(int quantity)
    {
        return new Faker<Attendant>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.IsActive, f => true)
            .RuleFor(x => x.Customers, CustomerFaker.Generate(quantity))
            .Generate(quantity);
    }
}
