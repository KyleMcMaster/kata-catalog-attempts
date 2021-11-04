using FluentAssertions;
using Kata.Starter.Fixtures;
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
            sut.Level.Should().BeEquivalentTo(Level.BLUE);
        }

        [Theory]
        [AutoDomainData]
        public void Game_AddSurvivor_AddsSurvivorAndDoesNotEndGame(string name)
        {
            var sut = new Game();

            var survivor = Survivor.CreateNew(name);

            sut.AddSurvivor(survivor);

            sut.IsOver.Should().BeFalse();
            sut.Survivors.Should().HaveCount(1);
        }

        [Theory]
        [AutoDomainData]
        public void Game_IsOver_WhenAllPlayersAreDead(string name)
        {
            var sut = new Game();

            var survivor = Survivor
                .CreateNew(name)
                .ReceiveWound()
                .ReceiveWound();

            sut.AddSurvivor(survivor);

            sut.IsOver.Should().BeTrue();
            sut.Survivors.Should().HaveCount(1);
        }

        [Theory]
        [AutoDomainData]
        public void Game_Level_BeginsAtBlue(string name)
        {
            var sut = new Game();

            var survivor = Survivor.CreateNew(name);

            sut.AddSurvivor(survivor);

            sut.Level.Should().BeEquivalentTo(Level.BLUE);
        }

        [Fact]
        public void Game_Level_EqualsLevelOfHighestSurvivor()
        {
            var sut = new Game();

            var blueSurvivor = Survivor.CreateNew("blue");

            for (int i = 0; i < Level.BLUE.MinimumExperience; i++)
            {
                blueSurvivor = blueSurvivor.KillZombie();
            }

            sut.AddSurvivor(blueSurvivor);

            var redSurvivor = Survivor.CreateNew("red");

            for (int i = 0; i < Level.RED.MinimumExperience; i++)
            {
                redSurvivor = redSurvivor.KillZombie();
            }

            sut.Survivors.Add(redSurvivor);

            var yellowSurvivor = Survivor.CreateNew("yellow");

            for (int i = 0; i < Level.YELLOW.MinimumExperience; i++)
            {
                yellowSurvivor = yellowSurvivor.KillZombie();
            }

            sut.Survivors.Add(yellowSurvivor);

            sut.Level.Should().BeEquivalentTo(Level.RED);
        }
    }
}
