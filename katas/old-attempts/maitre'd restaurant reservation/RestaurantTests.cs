using FluentAssertions;
using Kata.Starter.Fixtures;
using System;
using Xunit;

namespace Kata.Starter
{
    public class RestaurantTests
    {
        private readonly int defaultMaxCapacity = 20;

        [Fact]
        public void Constructor_Returns_Non_Null_Instance_And_Assigns_Fields_Using_Supplied_Values()
        {
            var sut = new Restaurant(defaultMaxCapacity);

            sut.Should().NotBeNull();
            sut.Capacity.Should().Be(defaultMaxCapacity);
            sut.AcceptedReservations.Should().BeEmpty();
        }

        [Theory, AutoDomainData]
        public void Restaurant_Accepts_Request_Less_Than_Max_Capacity(string name, DateTimeOffset date, string nextName)
        {
            int numberOfDiners = 2;

            var sut = new Restaurant(defaultMaxCapacity);

            var acceptableRequest = new Request(
                name: nextName,
                date: date,
                numberOfDiners: numberOfDiners);

            var acceptedReservation = sut.ProcessRequest(acceptableRequest);

            acceptedReservation.IsSome.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public void Restaurant_Rejects_Request_Greater_Than_Max_Capacity(string name, DateTimeOffset date, string nextName)
        {
            int numberOfDiners = 2;

            var sut = new Restaurant(defaultMaxCapacity);

            var previousRequest = new Request(
                name: name,
                date: date,
                numberOfDiners: defaultMaxCapacity - 1);

            sut.ProcessRequest(previousRequest);

            var maxCapactyRequest = new Request(
                name: nextName,
                date: date,
                numberOfDiners: numberOfDiners);

            var rejectedReservation = sut.ProcessRequest(maxCapactyRequest);

            rejectedReservation.IsNone.Should().BeTrue();
        }
    }
}
