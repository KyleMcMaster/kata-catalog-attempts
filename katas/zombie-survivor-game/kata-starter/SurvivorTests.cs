using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Kata.Starter.Fixtures;
using Xunit;

namespace Kata.Starter
{
    public class SurvivorTests
    {
        private string Name { get; }

        public SurvivorTests()
        {
            var fixture = new Fixture();

            Name = fixture.Create<string>();
        }

        [Fact]
        public void Survivor_Returns_Non_Null_Instance()
        {
            var sut = new Survivor(Name);

            sut.Should().NotBeNull();
        }

        [Fact]
        public void Survivor_Has_A_Name()
        {
            var sut = new Survivor(Name);

            sut.Name.Should().Be(Name);
        }

        [Fact]
        public void Survivor_Begins_With_Zero_Wounds()
        {
            var sut = new Survivor(Name);

            sut.Wounds.Should().Be(0);
        }

        [Fact]
        public void Survivor_Who_Receives_Two_Wounds_Dies_Immediately()
        {
            var sut = new Survivor(Name);

            sut.ReceiveWound(2);

            sut.Status.Should().Be("DEAD");
        }

        [Theory, AutoDomainData]
        public void Additional_Wounds_After_2_Are_Ignored(int additionalWounds)
        {
            var sut = new Survivor(Name);

            sut.ReceiveWound(2);
            sut.ReceiveWound(additionalWounds);

            sut.Wounds.Should().Be(2);
        }

        [Fact]
        public void Survivor_Starts_With_Three_Available_Actions_Per_Turn()
        {
            var sut = new Survivor(Name);

            sut.MaxActions.Should().Be(3);
        }

        [Fact]
        public void Survivor_Can_Carry_A_Maximum_Of_Five_Pieces_Of_Equipment()
        {
            var sut = new Survivor(Name);

            sut.AddEquipment(new Equipment());
            sut.AddEquipment(new Equipment());
            sut.AddEquipment(new Equipment());
            sut.AddEquipment(new Equipment());
            sut.AddEquipment(new Equipment());
            Action greaterThanFiveEquipment = () => sut.AddEquipment(new Equipment());

            greaterThanFiveEquipment.Should().Throw<Exception>();
        }

        [Fact]
        public void Survivor_Can_Carry_A_Maximum_Of_Five_Pieces_Of_Equipment_Also()
        {
            var sut = new Survivor(Name);

            try
            {
                sut.AddEquipment(new Equipment());
                sut.AddEquipment(new Equipment());
                sut.AddEquipment(new Equipment());
                sut.AddEquipment(new Equipment());
                sut.AddEquipment(new Equipment());
                sut.AddEquipment(new Equipment());
            }
            catch (Exception e)
            {
            }

            sut.Equipment.Count.Should().Be(5);
        }

        [Fact]
        public void Survivor_Can_Carry_A_Maximum_Of_Two_Pieces_Of_Equipment_In_Hand()
        {
            var sut = new Survivor(Name);

            sut.AddEquipment(new Equipment("Dennis", "InHand"));
            sut.AddEquipment(new Equipment("Chucri", "InHand"));

            Action greaterThanTwoInHand = () => sut.AddEquipment(new Equipment("Nathan", "InHand"));

            greaterThanTwoInHand.Should().Throw<Exception>();
        }

        [Fact]
        public void Survivor_Can_Carry_Equipment_With_Two_In_Hand_And_Three_In_Reserve()
        {
            var sut = new Survivor(Name);

            sut.AddEquipment(new Equipment("Dennis", "InHand"));
            sut.AddEquipment(new Equipment("Chucri", "InHand"));
            sut.AddEquipment(new Equipment("Nathan", "InReserve"));
            sut.AddEquipment(new Equipment("Gary", "InReserve"));
            sut.AddEquipment(new Equipment("Jonathan", "InReserve"));

            int inHandCount = sut.Equipment.Count(e => e.Type == "InHand");
            int inReserveCount = sut.Equipment.Count(e => e.Type == "InReserve");

            inHandCount.Should().Be(2);
            inReserveCount.Should().Be(3);
        }

        [Fact]
        public void Survivor_Can_Carry_All_Equipment_In_Reserve()
        {
            var sut = new Survivor(Name);

            sut.AddEquipment(new Equipment("Dennis", "InReserve"));
            sut.AddEquipment(new Equipment("Chucri", "InReserve"));
            sut.AddEquipment(new Equipment("Nathan", "InReserve"));
            sut.AddEquipment(new Equipment("Gary", "InReserve"));
            sut.AddEquipment(new Equipment("Jonathan", "InReserve"));

            int inReserveCount = sut.Equipment.Count(e => e.Type == "InReserve");

            inReserveCount.Should().Be(5);
        }

        [Theory]
        [InlineData(1)]
        public void Survivor_With_One_Wound_Can_Only_Carry_Four_Equipment(int numberOfWounds)
        {
            var sut = new Survivor(Name);

            sut.AddEquipment(new Equipment("Dennis", "InReserve"));
            sut.AddEquipment(new Equipment("Chucri", "InReserve"));
            sut.AddEquipment(new Equipment("Nathan", "InReserve"));
            sut.AddEquipment(new Equipment("Gary", "InReserve"));
            sut.AddEquipment(new Equipment("Jonathan", "InReserve"));

            sut.ReceiveWound(numberOfWounds);

            sut.Equipment.Count.Should().Be(4);
        }

        [Fact]
        public void Survivor_Begins_With_Zero_Experience()
        {
            var sut = new Survivor(Name);

            sut.Experience.Should().Be(0);
        }

        [Fact]
        public void Survivor_Begins_At_Level_Blue()
        {
            var sut = new Survivor(Name);

            sut.CurrentLevel.Should().Be("Blue");
        }
    }
}
