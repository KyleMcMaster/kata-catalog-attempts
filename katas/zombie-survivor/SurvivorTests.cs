using FluentAssertions;
using Xunit;

namespace Kata.Starter
{
    public class SurvivorTests
    {
        [Theory]
        [InlineData("Kyle")]
        public void Survivor_Constructor_SetsName(string name)
        {
            var sut = new Survivor(name);

            sut.Name.Should().Be(name);
        }

        [Theory]
        [InlineData("Sean")]
        public void Survivor_Constructor_SetsWoundsToZero(string name)
        {
            var sut = new Survivor(name);

            sut.Wounds.Should().Be(0);
        }

        [Theory]
        [InlineData("David")]
        public void Survivor_Constructor_SetsIsAliveTrue(string name)
        {
            var sut = new Survivor(name);

            sut.IsAlive.Should().BeTrue();
        }

        [Theory]
        [InlineData("Kyle")]
        public void Survivor_Constructor_SetsActionCountToThree(string name)
        {
            var sut = new Survivor(name);

            sut.ActionCount.Should().Be(3);
        }

        [Theory]
        [InlineData("Kyle", 1, 1)]
        [InlineData("Kyle", 2, 2)]
        [InlineData("Kyle", 3, 2)]
        public void Survivor_ReceivesWound_CalledOnceReturnsOneWound(string name, int numberOfWounds, int expected)
        {
            var initial = new Survivor(name);

            Survivor result = initial;
            for (int i = 0; i < numberOfWounds; i++)
            {
                result = result.ReceiveWound();
            }

            result.Wounds.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kyle")]
        public void Survivor_ReceivesWound_CalledRTwiceReturnsDeadSurvivor(string name)
        {
            var initial = new Survivor(name);

            var sut = initial.ReceiveWound();
            sut = sut.ReceiveWound();

            sut.IsAlive.Should().BeFalse();
            sut.Wounds.Should().Be(2);
        }
    }
}
