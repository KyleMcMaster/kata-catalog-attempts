using FluentAssertions;
using Xunit;

namespace Kata.Starter
{
    public class GameTests
    {
        [Fact]
        public void Game_BeginsWithZeroSurvivors()
        {
            var sut = new Game();

            sut.Survivors.Should().BeEmpty();
            sut.IsOver.Should().BeFalse();
        }
    }
}
