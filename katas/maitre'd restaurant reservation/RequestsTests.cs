using FluentAssertions;
using System;
using Xunit;

namespace Kata.Starter
{
    public class RequestsTests
    {
        public string defaultName = "McFun";
        public DateTimeOffset defaultDate = DateTimeOffset.UtcNow;
        public int defaultNumberOfDiners = 2;

        // Arrange 
        // Act
        // Asset
        [Fact]
        public void Constructor_Returns_Non_Null_Instance_And_Assigns_Fields_Using_Supplied_Values()
        {
            var sut = new Request(
                name: defaultName,
                date: defaultDate,
                numberOfDiners: defaultNumberOfDiners);

            sut.Should().NotBeNull();
            sut.Name.Should().Be(defaultName);
            sut.Date.Should().Be(defaultDate);
            sut.NumberOfDiners.Should().Be(defaultNumberOfDiners);
        }
    }
}
