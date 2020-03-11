using FluentAssertions;
using Kata.Starter.Fixtures;
using Xunit;

namespace Kata.Starter
{
    public class SurvivorTests
    {
        [Theory, AutoDomainData]
        public void Survivor_Has_A_Name(string name)
        {
            var sut = new Survivor(name);

            sut.Name.Should().Be(name);
        }

        [Theory, AutoDomainData]
        public void Survivor_Begins_With_Zero_Wounds(string name)
        {
            var sut = new Survivor(name);

            sut.Wounds.Should().Be(0);
        }

        [Theory, AutoDomainData]
        public void Survivor_Who_Receives_Two_Wounds_Dies_Immediately(string name)
        {
            var sut = new Survivor(name);

            sut.ReceiveWound(2);

            sut.Status.Should().Be("DEAD");
        }

        [Theory, AutoDomainData]
        public void Additional_Wounds_After_2_Are_Ignored(string name, uint additionalWounds)
        {
            var sut = new Survivor(name);

            sut.ReceiveWound(2);
            sut.ReceiveWound(additionalWounds);

            sut.Wounds.Should().Be(2);
        }

        [Theory, AutoDomainData]
        public void Survivor_Starts_With_Three_Available_Actions_Per_Turn(string name)
        {
            var sut = new Survivor(name);

            sut.MaxActions.Should().Be(3);
        }
    }
}
