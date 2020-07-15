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

            sut.Roll();

            sut.DiceValues.Any(dv => dv != 0).Should().BeTrue();
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 3, 1, 1, 0 })]
        public void Roll_With_34533_Produces_Score_Of_350(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(350);
        }

        [Theory]
        [InlineData(new int[] { 4, 0, 0, 0, 1, 0 })]
        public void Roll_With_11151_Produces_Score_Of_1150(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(1150);
        }

        [Theory]
        [InlineData(new int[] { 0, 2, 1, 1, 0, 5 })]
        public void Roll_With_23462_Produces_Score_Of_0(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(0);
        }
    }
}
