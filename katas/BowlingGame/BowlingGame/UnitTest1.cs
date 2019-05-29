using BowlingGame;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Assert_Gutter_Game()
        {
            // Arrange
            var game = new Game();
            int rolls = 20;
            int pins = 0;
            int expectedScore = rolls * pins;

            // Act
            RollMany(game, rolls, pins);

            // Assert
            Assert.AreEqual(expectedScore, game.Score());
        }

        [Test]
        public void Assert_All_Ones()
        {
            // Arrange
            var game = new Game();
            int rolls = 20;
            int pins = 1;
            int expectedScore = rolls * pins;

            // Act
            RollMany(game, rolls, pins);

            // Assert
            int score = game.Score();
            Assert.AreEqual(expectedScore, game.Score());
        }

        [Test]
        public void Assert_One_Spare()
        {
            // Arrange
            var game = new Game();
            int thirdScore = 3;

            // Act
            rollSpare(game);
            game.Roll(thirdScore);
            RollMany(game, 17, 0);

            // Assert
            Assert.AreEqual(16, game.Score());
        }

        private void rollSpare(Game g)
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollMany(Game g, int n, int pins)
        {
            for (int i = 1; i <= n; i++)
            {
                g.Roll(pins);
            }
        }
    }
}