using System;

namespace Kata.Starter
{
    public class Game
    {
        public int[] DiceValues { get; protected set; } = new int[6] { 0, 0, 0, 0, 0, 0 };

        public void Roll()
        {
            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                var dieValue = rnd.Next(0, 6);
                DiceValues[dieValue] = DiceValues[dieValue] + 1;
            }
        }

        public int Score(int[] testdata = null)
        {
            if (testdata != null)
            {
                DiceValues = testdata;
            }

            int score = 0;
            int index = -1;
            int numberOfOccurences = 6;

            while (index == -1 && numberOfOccurences >= 3)
            {
                index = Array.IndexOf(DiceValues, numberOfOccurences);
                numberOfOccurences--;
            }

            switch (index)
            {
                case 0:
                    score += 1000;
                    break;
                case 2:
                    score += 300;
                    break;
                default:
                    break;
            }

            if (DiceValues[0] % 3 == 1)
            {
                score += 100;
            }

            // if (DiceValues[1] % 2 == 1)
            // {
            //     score += 100;
            // }

            if (DiceValues[4] % 3 == 1)
            {
                score += 50;
            }

            return score;
        }
    }
}
