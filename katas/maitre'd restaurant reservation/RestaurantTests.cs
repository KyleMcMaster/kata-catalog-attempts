using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kata.Starter
{
    public class RestaurantTests
    {
        private readonly IFixture fixture;

        public int defaultMaxCapacity = 20;

        

        [Fact]
        public void Constructor_Returns_Non_Null_Instance_And_Assigns_Fields_Using_Supplied_Values()
        {
            var sut = new Restaurant(defaultMaxCapacity);

            sut.Should().NotBeNull();
            sut.Capacity.Should().Be(defaultMaxCapacity);
        }

        public void Accepts_Request_Within_Max_Capacity()
        {
            var sut = new Restaurant(defaultMaxCapacity);


        }
    }
}
