using FluentAssertions;
using Kata.Starter.Fixtures;
using System;
using Xunit;

namespace Kata.Starter
{
    public class SurvivorTests
    {
        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_SetsName(string name)
        {
            var sut = Survivor.CreateNew(name);

            sut.Name.Should().Be(name);
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_SetsWoundsToZero(string name)
        {
            var sut = Survivor.CreateNew(name);

            sut.Wounds.Should().Be(0);
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_SetsIsAliveTrue(string name)
        {
            var sut = Survivor.CreateNew(name);

            sut.IsAlive.Should().BeTrue();
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_SetsActionCountToThree(string name)
        {
            var sut = Survivor.CreateNew(name);

            sut.ActionCount.Should().Be(3);
        }

        [Theory]
        [InlineData("Kyle", 1, 1)]
        [InlineData("Kyle", 2, 2)]
        [InlineData("Kyle", 3, 2)]
        public void Survivor_ReceivesWound_CalledOnceReturnsOneWound(string name, int numberOfWounds, int expected)
        {
            var initial = Survivor.CreateNew(name);

            Survivor result = initial;
            for (int i = 0; i < numberOfWounds; i++)
            {
                result = result.ReceiveWound();
            }

            result.Wounds.Should().Be(expected);
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_ReceivesWound_CalledRTwiceReturnsDeadSurvivor(string name)
        {
            var initial = Survivor.CreateNew(name);

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
            var initial = Survivor.CreateNew(name)
                .AddEquipment(new Equipment("Katana", EquipmentStatus.IN_HAND))
                .AddEquipment(new ("Baseball Bat", EquipmentStatus.IN_HAND))
                .AddEquipment(new ("Pistol", EquipmentStatus.IN_RESERVE))
                .AddEquipment(new ("Bottled Water", EquipmentStatus.IN_RESERVE))
                .AddEquipment(new ("Molotov", EquipmentStatus.IN_RESERVE));

            Survivor result = initial;
            for (int i = 0; i < numberOfWounds; i++)
            {
                result = result.ReceiveWound();
            }

            result.Equipment.Should().HaveCount(expected);
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_ThrowsWithMoreThanTwoEquipmentInHand(string name)
        {
            Action create = () => Survivor.CreateNew(name)
                .AddEquipment(new Equipment("Katana", EquipmentStatus.IN_HAND))
                .AddEquipment(new("Baseball Bat", EquipmentStatus.IN_HAND))
                .AddEquipment(new("Pistol", EquipmentStatus.IN_HAND));

            create.Should().Throw<ArgumentException>();
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_CreateNew_SetsExperienceToZero(string name)
        {
            var sut = Survivor.CreateNew(name);

            sut.Experience.Should().Be(0);
        }

        [Theory]
        [AutoDomainData]
        public void Survivor_HasCurrentLevel(string name)
        {
            var result = LevelCalculator.Calculate(Survivor.CreateNew(name).Experience);

            result.Should().BeEquivalentTo(Level.BLUE);
        }
    }
}
