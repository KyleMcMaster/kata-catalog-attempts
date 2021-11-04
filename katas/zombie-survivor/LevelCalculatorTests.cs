using FluentAssertions;
using Kata.Starter.Fixtures;
using Xunit;

namespace Kata.Starter
{
    public class LevelCalculatorTests
    {
        [Fact]
        public void LevelCalculator_Calculates_SurvivorWithZeroExperienceAsBlue()
        {
            var result = LevelCalculator.Calculate(Level.BLUE.MinimumExperience);

            result.Should().BeEquivalentTo(Level.BLUE);
        }

        [Fact]
        public void LevelCalculator_Calculates_SurvivorWithSixExperienceAsYellow()
        {
            var result = LevelCalculator.Calculate(Level.YELLOW.MinimumExperience);

            result.Should().BeEquivalentTo(Level.YELLOW);
        }

        [Fact]
        public void LevelCalculator_Calculates_SurvivorWithEighteenExperienceAsOrange()
        { 
            var result = LevelCalculator.Calculate(Level.ORANGE.MinimumExperience);

            result.Should().BeEquivalentTo(Level.ORANGE);
        }

        [Fact]
        public void LevelCalculator_Calculates_SurvivorWithFortyTwoExperienceAsRed()
        {
            var result = LevelCalculator.Calculate(Level.RED.MinimumExperience);

            result.Should().BeEquivalentTo(Level.RED);
        }
    }
}
