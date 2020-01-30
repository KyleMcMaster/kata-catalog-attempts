using FluentAssertions;
using Kata.Starter.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kata.Starter
{
    public class ReservationTests
    {

        [Theory, AutoDomainData]
        public void Constructor_Returns_Non_Null_Instance_And_Assigns_Fields_Using_Supplied_Values(Request request)
        {
            var sut = new Reservation(request);

            sut.Should().NotBeNull();
            sut.Name.Should().Be(request.Name);
            sut.Date.Should().Be(request.Date);
            sut.NumberOfDiners.Should().Be(request.NumberOfDiners);
        }
    }
}
