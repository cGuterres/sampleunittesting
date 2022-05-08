﻿using AutoFixture.Xunit2;
using MockQueryable.Moq;
using Moq;
using SampleUnitTesting.Domain;
using SampleUnitTesting.Infrastructure;
using SampleUnitTesting.Tests.AutoFixture;
using Xunit;

namespace SampleUnitTesting.Tests.NSubstitute
{
    public sealed class AttendantRepositoryTests
    {
        public IEnumerable<Attendant> ArrangeData(int quantity)
        {
            return AttendantFaker.Generate(quantity);
        }

        public IEnumerable<Attendant> ArrangeDataWithCustomers(int quantity)
        {
            return AttendantFaker.GenerateWithClients(quantity);
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllAsync"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAll_When_Success([Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var mockList = ArrangeData(10).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());
            
            foreach (var item in result)
            {
                Assert.Equal(0, item.Customers.Count);
            }
        }

        [Theory(DisplayName = "Test Attendant Repository FindAllWithCustomersAsync"), Trait("Category", "UnitTest")]
        [AutoDomainData]
        public async Task FindAllWithCustomersAsync_When_Success([Frozen] Mock<ISampleUnitTestingDbContext> dbContext)
        {
            // Arrange
            var mockList = ArrangeDataWithCustomers(10).BuildMock().BuildMockDbSet().Object;

            dbContext
              .Setup(c => c.GetDbSet<Attendant>()).Returns(mockList);

            var repository = new AttendantRepository(dbContext.Object);

            // Act
            var result = await repository.FindAllWithCustomersAsync();

            // Assert
            Assert.Equal(mockList.Count(), result.Count());

            foreach (var item in result)
            {
                Assert.Equal(10, item.Customers.Count);
            }
        }
    }
}
