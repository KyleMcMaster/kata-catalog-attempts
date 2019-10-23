using Xunit;

namespace MineField
{
    public class MineFieldTest
    {
        [Fact]
        public void InitializingMineField()
        {
            // length, width, mines
            var mineField = new MineField(3, 4, 2);
            char[,] expectedField = mineField.Field;
            Assert.NotNull(mineField);
            Assert.Equal(3, expectedField.GetLength(0));
            Assert.Equal(4, expectedField.GetLength(1));
        }

        [Fact]
        public void MineFieldCanContainMines()
        {
            var mineField = new MineField(3, 4, 2);

            Assert.Contains('*', mineField.Field[0, 0].ToString());
        }

        [Fact]
        public void MineFieldContainsCorrectNumberOfMines()
        {
            var mineField = new MineField(3, 4, 2);

            int count = mineField.GetMineCount();

            Assert.Equal(2, count);
        }

        [Fact]
        public void MineFieldCanContainHints()
        {
            // length, width, mines
            var mineField = new MineField(3, 4, 2);

        }
    }

    public static class Extensions
    {
        public static int GetMineCount(this MineField mineField)
        {
            int sum = 0;

            for (int l = 0; l < mineField.Length; l++)
            {
                for (int w = 0; w < mineField.Width; w++)
                {
                    if (mineField.Field[l, w] == '*')
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }
    }
}