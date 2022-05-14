using AutoFixture.Xunit2;
using MockQueryable.Moq;
using Moq;
using SampleUnitTesting.Domain;
using SampleUnitTesting.Infrastructure;
using SampleUnitTesting.Tests.AutoFixture;
using Xunit;

namespace SampleUnitTesting.Tests.Moq
{
    public sealed class AttendantRepositoryTests
    {
        public IEnumerable<Attendant> ArrangeData(int quantity = 10)
        {
            return AttendantFaker.Generate(quantity);
        }

        public IEnumerable<Attendant> ArrangeDataWithCustomers(int quantity = 10)
        {
            return AttendantFaker.GenerateWithClients(quantity);
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllAsync"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAll_When_Success([Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var mockList = ArrangeData().BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());

            foreach (var item in result)
            {
                Assert.Empty(item.Customers);
            }
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllAsync when return an empty list"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAll_When_EmptyList(
            [Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var quantity = 0;
            var mockList = ArrangeData(quantity).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllWithCustomersAsync"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAllWithCustomersAsync_When_Success([Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var quantity = 10;
            var mockList = ArrangeDataWithCustomers().BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllWithCustomersAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());

            foreach (var item in result)
            {
                Assert.NotEmpty(item.Customers);
                Assert.Equal(quantity, item.Customers.Count);
            }

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllWithCustomersAsync when repository return empty list"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAllWithCustomersAsync_When_EmptyList([Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var quantity = 0;
            var mockList = ArrangeDataWithCustomers(quantity).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllWithCustomersAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAsyncWithCustomersAsync return a especific attendant"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAsyncWithCustomersAsync_When_Success(
            [Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var id = 1;
            var mockList = ArrangeDataWithCustomers().BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindWithCustomersAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result?.Id, id);

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAsyncWithCustomersAsync return null"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAsyncWithCustomersAsync_When_NotFound(
            [Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var id = 1;
            var mockList = ArrangeDataWithCustomers(0).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindWithCustomersAsync(id);

            // Assert
            Assert.Null(result);

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAsyncAsync return a especific attendant"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAsyncAsync_When_Success(
            [Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var id = 1;
            var mockList = ArrangeData().BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result?.Id, id);

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }

        [Theory(DisplayName = "Test Attendant Repository FindAsyncAsync return null"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAsyncAsync_When_NotFound(
            [Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var id = 1;
            var mockList = ArrangeData(0).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAsync(id);

            // Assert
            Assert.Null(result);

            dbContext.Verify(x => x.GetDbSet<Attendant>(), Times.Once());
        }
    }
}
