using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.NSubstitute;
using NSubstitute;
using SampleUnitTesting.Domain;
using SampleUnitTesting.Infrastructure;

namespace SampleUnitTesting.Tests.NSubstitute
{
    [TestClass]
    public sealed class AttendantRepositoryTests
    {
        private readonly ISampleUnitTestingDbContext _dbContext = Substitute.For<ISampleUnitTestingDbContext>();

        public IEnumerable<Attendant> ArrangeData(int quantity = 10)
        {
            return AttendantFaker.Generate(quantity);
        }

        public IEnumerable<Attendant> ArrangeDataWithCustomers(int quantity = 10)
        {
            return AttendantFaker.GenerateWithClients(quantity);
        }

        [TestMethod("Test Attendant Repository FindAllAsync")]
        public async Task FindAllAsync_When_Success()
        {
            // arrange
            var mockList = ArrangeData(10).BuildMock().BuildMockDbSet();

            var repository = new AttendantRepository(_dbContext);

            _dbContext.GetDbSet<Attendant>().Returns(mockList);

            // act
            var result = await repository.FindAllAsync();

            // assert

            Assert.IsNotNull(result);

            _dbContext.Received().GetDbSet<Attendant>();
        }
    }
}
