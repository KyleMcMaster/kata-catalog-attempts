namespace Kata.Starter
{
    public interface IRule
    {
        int Evaluate(int[] diceValues);
    }

    public class SingleFiveRule : IRule
    {
        public int Evaluate(int[] diceValues) =>
            diceValues[4] % 3 == 1
            ? 50
            : 0;
    }

    public class SingleOneRule : IRule
    {
        public int Evaluate(int[] diceValues) =>
        diceValues[0] % 3 == 1 ?
        100 :
        0;
    }

    public class TripleRule : IRule
    {
        private readonly int side;
        private readonly int value;

        public TripleRule(int side, int value)
        {
            this.side = side;
            this.value = value;
        }

        public int Evaluate(int[] diceValues) =>
            diceValues[side - 1] >= 3 ?
            value :
            0;
    }
}
