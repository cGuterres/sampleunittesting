using Bogus;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Tests;

public static class CustomerFaker
{
    public static IEnumerable<Customer> Generate(int quantity = 10)
    {
        return new Faker<Customer>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.IsActive, f => true)
            .Generate(quantity);
    }
}
