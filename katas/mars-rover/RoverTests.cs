using System;
using Xunit;

namespace mars_rover
{
    public class RoverTests
    {
        [Fact]
        public void Rover_Constructor_Produces_Not_Null_Rover()
        {
            var sut = new Rover();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Rover_Starts_With_Initial_Starting_Point()
        {
            var expectedPoint = Tuple.Create(0, 0);

            var sut = new Rover();

            Assert.Equal(sut.Point(), expectedPoint);
        }

        [Fact]
        public void Rover_Starts_With_Valid_Direction()
        {
            char expectedDirection = 'N';

            var sut = new Rover();

            Assert.Equal(sut.Facing(), expectedDirection);
        }

        [Fact]
        public void Rover_Recieves_Array_Of_Commands()
        {
            var expectedCommands = new[] { 'f', 'b' };

            var sut = new Rover();
            sut.AddCommands(expectedCommands);

            Assert.Equal(expectedCommands, sut.commands);
        }

        [Fact]
        public void Rover_Implements_Command_To_Move_Forward()
        {
            var forwardCommand = new[] { 'f' };
            var expectedPoint = Tuple.Create(0, 1);

            var sut = new Rover();
            sut.AddCommands(forwardCommand);
            sut.executeCommands();

            Assert.Equal(sut.Point(), expectedPoint);
        }

        [Fact]
        public void Rover_Implements_Command_To_Move_Backward()
        {
            var backwardCommand = new[] { 'b' };
            var expectedPoint = Tuple.Create(0, -1);

            var sut = new Rover();
            sut.AddCommands(backwardCommand);
            sut.executeCommands();

            Assert.Equal(sut.Point(), expectedPoint);
        }
    }
}
