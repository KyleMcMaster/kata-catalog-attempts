using FluentAssertions;
using Xunit;

namespace Kata.Starter
{
    public class GameControllerTests
    {
        private GameController sut;

        public GameControllerTests()
        {
            sut = new GameController();
        }

        [Fact]
        public void Game_Begins_With_Zero_Survivors()
        {
            sut = new GameController();

            sut.Survivors.Should().BeEmpty();
        }

        [Fact]
        public void Game_Allows_Addition_Of_Survivors()
        {
            sut = new GameController();

            var newSurvivor = new Survivor("Kyle");

            sut.AddSurvivor(newSurvivor);

            sut.Survivors.Count.Should().Be(1);
        }

        //This is only guarding against the object, not the name.
        [Fact]
        public void Game_Does_Not_Allow_Duplicate_Survivors()
        {
            var firstSurvivor = new Survivor("Kyle");
            var secondSurvivor = new Survivor("Nathan");
            var duplicateSurvivor = new Survivor("Nathan");

            sut.AddSurvivor(firstSurvivor);
            sut.AddSurvivor(secondSurvivor);
            sut.AddSurvivor(duplicateSurvivor);

            sut.Survivors.Count.Should().Be(2);
        }
    }
}
