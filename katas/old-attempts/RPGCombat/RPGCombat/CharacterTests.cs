using NUnit.Framework;
using RPGCombat;

namespace Tests
{
    public class CharacterTests
    {
        // All characters when created have health 1000
        [Test]
        public void Assert_Health_Starts_At_One_Thousand()
        {
            // Arrange (and Act)
            var sut = new Character(1000, 1, true);

            // Assert
            Assert.AreEqual(1000, sut.Health);
        }

        // All characters when created have level 1
        [Test]
        public void Assert_Level_Starts_At_One()
        {
            // Arrange (and Act)
            var sut = new Character(1000, 1, true);

            // Assert
            Assert.AreEqual(1, sut.Level);
        }

        // All characters when created are alive (Alive == true)
        [Test]
        public void Assert_Alive_Starts_At_True()
        {
            // Arrange (and Act)
            var sut = new Character(1000, 1, true);

            // Assert
            Assert.AreEqual(true, sut.IsAlive);
        }

        // Damage is subtracted from health
        [Test]
        public void Assert_Character_Took_Damage()
        {
            // Arrange
            var sut = new Character(1000, 1, true);

            // Act
            sut.TakeDamage(500);

            // Assert
            Assert.AreEqual(500, sut.Health);
        }

        // When damage received exceeds current Health, Health becomes 0 and the character dies
        [Test]
        public void Assert_Character_With_Zero_Health_Is_Dead()
        {
            // Arrange
            var sut = new Character(1000, 1, true);

            // Act
            sut.TakeDamage(1001);

            // Assert
            Assert.False(sut.IsAlive);
        }

        // Dead characters cannot be healed
        [Test]
        public void Assert_Dead_Character_Cannot_Be_Healed()
        {
            // Arrange
            var sut = new Character(1000, 1, false);

            // Act
            sut.Heal();

            // Assert
            Assert.AreEqual(1000, sut.Health);
        }

        // Healing cannot raise health above 1000
        [Test]
        public void Assert_Character_Health_Cannot_Exceed_One_Thousand()
        {
            // Arrange
            var sut = new Character(1000, 1, true);

            // Act
            sut.Heal();

            // Assert
            Assert.AreEqual(1000, sut.Health);
        }
    }
}