namespace Kata.Starter
{
    public static class LevelCalculator
    {
        public static Level Calculate(int experience)
        {
            switch (experience)
            {
                case >= 42:
                    return Level.RED;
                case >= 18:
                    return Level.ORANGE;
                case >= 6:
                    return Level.YELLOW;
                default:
                    return Level.BLUE;
            }
        }
    }
}
