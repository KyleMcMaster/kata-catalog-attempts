using FluentAssertions;
using System.Linq;
using Xunit;

namespace Kata.Starter
{
    public class SurvivorTests
    {
        [Theory]
        [InlineData("Kyle")]
        public void Survivor_Constructor_SetsName(string name)
        {
            var sut = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

            sut.Name.Should().Be(name);
        }

        [Theory]
        [InlineData("Sean")]
        public void Survivor_Constructor_SetsWoundsToZero(string name)
        {
            var sut = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

            sut.Wounds.Should().Be(0);
        }

        [Theory]
        [InlineData("David")]
        public void Survivor_Constructor_SetsIsAliveTrue(string name)
        {
            var sut = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

            sut.IsAlive.Should().BeTrue();
        }

        [Theory]
        [InlineData("Kyle")]
        public void Survivor_Constructor_SetsActionCountToThree(string name)
        {
            var sut = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

            sut.ActionCount.Should().Be(3);
        }

        [Theory]
        [InlineData("Kyle", 1, 1)]
        [InlineData("Kyle", 2, 2)]
        [InlineData("Kyle", 3, 2)]
        public void Survivor_ReceivesWound_CalledOnceReturnsOneWound(string name, int numberOfWounds, int expected)
        {
            var initial = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

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
            var initial = Survivor.CreateNew(Enumerable.Empty<Equipment>(), name);

            var sut = initial.ReceiveWound();
            sut = sut.ReceiveWound();

            sut.IsAlive.Should().BeFalse();
            sut.Wounds.Should().Be(2);
        }

        [Theory]
        [InlineData("Kyle", 1, 4)]
        [InlineData("Kyle", 2, 3)]
        [InlineData("Kyle", 3, 3)]
        public void Survivor_ReceivesWound_RemovesEquipment(string name, int numberOfWounds, int expected)
        {
            var equipment = new Equipment[]
            {
                new Equipment("Katana", EquipmentStatus.IN_HAND),
                new Equipment("Baseball Bat", EquipmentStatus.IN_HAND),
                new Equipment("Pistol", EquipmentStatus.IN_RESERVE),
                new Equipment("Bottled Water", EquipmentStatus.IN_RESERVE),
                new Equipment("Molotov", EquipmentStatus.IN_RESERVE)
            };

            var initial = Survivor.CreateNew(equipment, name);

            Survivor result = initial;
            for (int i = 0; i < numberOfWounds; i++)
            {
                result = result.ReceiveWound();
            }

            result.Equipment.Should().HaveCount(expected);
        }
    }
}
