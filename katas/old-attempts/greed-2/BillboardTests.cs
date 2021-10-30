using System.Linq;
using FluentAssertions;
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

        [Fact]
        public void Jdawg_Good_Boy()
        {
            var sut = true;

            sut.Should().BeTrue();
        }

        [Fact]
        public void Roll_Initializes_IndividualScores_With_Values()
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
        [InlineData(new int[] { 0, 2, 1, 1, 0, 1 })]
        public void Roll_With_23462_Produces_Score_Of_0(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(0);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 1, 0, 0, 3 })]
        public void Roll_With_66623_Produces_Score_Of_600(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(600);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 1, 0, 3, 0 })]
        public void Roll_With_55523_Produces_Score_Of_500(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(500);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 1, 3, 0, 0 })]
        public void Roll_With_44423_Produces_Score_Of_400(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(400);
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 3, 2, 0, 0 })]
        public void Roll_With_33344_Produces_Score_Of_300(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(300);
        }

        [Theory]
        [InlineData(new int[] { 0, 3, 2, 0, 0, 0 })]
        public void Roll_With_22233_Produces_Score_Of_200(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(200);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 2, 0, 0, 0 })]
        public void Roll_With_12233_Produces_Score_Of_100(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(100);
        }

        [Theory]
        [InlineData(new int[] { 0, 2, 2, 0, 1, 0 })]
        public void Roll_With_52233_Produces_Score_Of_50(int[] testData)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(50);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 1, 3, 0, 0 }, 400)]
        [InlineData(new int[] { 0, 2, 2, 0, 1, 0 }, 50)]
        public void Roll_With_Supplied_Data_Produces_Expected_Score(int[] testData, int expectedScore)
        {
            var sut = new Game();

            sut.Roll();
            sut.Score(testData).Should().Be(expectedScore);
        }
    }
}
