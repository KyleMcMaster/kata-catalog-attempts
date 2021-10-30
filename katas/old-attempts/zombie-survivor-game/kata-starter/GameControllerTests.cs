using System.Linq;
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

        [Fact]
        public void Game_Level_Begins_At_Level_Blue()
        {
            sut = new GameController();

            sut.CurrentLevel.Should().Be("Blue");
        }

        [Fact]
        public void Game_Level_Equals_Highest_Living_Survivor_Level()
        {
            sut = new GameController();

            var firstSurvivor = new Survivor("Kyle");
            var secondSurvivor = new Survivor("Nathan");

            sut.AddSurvivor(firstSurvivor);
            sut.AddSurvivor(secondSurvivor);

            sut.KillZombie(firstSurvivor, 1);
            sut.KillZombie(secondSurvivor, 8);

            sut.CurrentLevel.Should().Be("Yellow");
        }

        [Fact]
        public void Survivor_Should_Gain_One_Experience_When_They_Kill_A_Zombie()
        {
            sut = new GameController();
            var firstSurvivor = new Survivor("Kyle");
            sut.AddSurvivor(firstSurvivor);
            int expectedExperience = firstSurvivor.Experience + 1;

            sut.KillZombie(firstSurvivor, 1);

            firstSurvivor.Experience.Should().Be(expectedExperience);
        }

        [Fact]
        public void Survivor_Exceeds_Six_Experience_Should_Advance_To_Yellow()
        {
            sut = new GameController();
            var firstSurvivor = new Survivor("Kyle");
            sut.AddSurvivor(firstSurvivor);

            sut.KillZombie(firstSurvivor, 7);

            firstSurvivor.CurrentLevel.Should().Be("Yellow");
        }

        [Fact]
        public void Survivor_Exceeds_Eighteen_Experience_Should_Advance_To_Orange()
        {
            sut = new GameController();
            var firstSurvivor = new Survivor("Kyle");
            sut.AddSurvivor(firstSurvivor);

            sut.KillZombie(firstSurvivor, 19);

            firstSurvivor.CurrentLevel.Should().Be("Orange");
        }

        [Fact]
        public void Survivor_Exceeds_FortyTwo_Experience_Should_Advance_To_Red()
        {
            sut = new GameController();
            var firstSurvivor = new Survivor("Kyle");
            sut.AddSurvivor(firstSurvivor);

            sut.KillZombie(firstSurvivor, 43);

            firstSurvivor.CurrentLevel.Should().Be("Red");
        }

        [Fact]
        public void Game_History_Notes_A_Suvivor_Has_Been_Added_To_Game()
        {
            sut = new GameController();

            var newSurvivor = new Survivor("Kyle");

            sut.AddSurvivor(newSurvivor);

            var addSurvivorEvent = sut.History.Events.FirstOrDefault(e => e.EntityId == "Kyle");

            addSurvivorEvent.EntityId.Should().Be("Kyle");
            addSurvivorEvent.EntityType.Should().Be(nameof(Survivor));
            addSurvivorEvent.Message.Should().Be("ADDED_TO_GAME");
        }
    }
}
