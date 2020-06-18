using System;
using System.Linq;
using AutoFixture.Idioms;
using FluentAssertions;
using Kata.Starter.Fixtures;
using Xunit;

namespace Kata.Starter
{
    public class BillboardTests
    {
        [Fact]
        public void Constructor_Returns_Non_Null_Instance()
        {
            var sut = new Game();

            sut.Should().NotBeNull();
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 3, 1, 1, 0 })]
        public void Roll_Initializes_IndividualScores_With_Values(int[] testData)
        {
            var sut = new Game();

            sut.Roll(testData);

            sut.DiceValues.Any(dv => dv != 0).Should().BeTrue();
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 3, 1, 1, 0 })]
        public void Roll_With_34533_Produces_Score_Of_350(int[] testData)
        {
            var sut = new Game();

            sut.Roll(testData);
            sut.Score().Should().Be(350);
        }
    }
}
