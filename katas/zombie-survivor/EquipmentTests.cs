using FluentAssertions;
using Xunit;

namespace Kata.Starter
{
    public class EquipmentTests
    {
        [Theory]
        [InlineData("Katana")]
        public void Equipment_Constructor_SetsNameAndStatus(string name)
        {
            var sut = new Equipment(name, EquipmentStatus.IN_HAND);

            sut.Name.Should().Be(name);
            sut.Status.Should().Be(EquipmentStatus.IN_HAND);
        }
    }
}
