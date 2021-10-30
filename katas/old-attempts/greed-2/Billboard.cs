using System;
using System.Collections.Generic;

namespace Kata.Starter
{
    public class Game
    {
        public int[] DiceValues { get; protected set; }
        private Random Random { get; }

        public List<IRule> Rules { get; }

        public Game()
        {
            DiceValues = new int[6] { 0, 0, 0, 0, 0, 0 };

            Random = new Random();

            Rules = new List<IRule>
            {
                new SingleFiveRule(),
                new SingleOneRule(),
                new TripleRule(1, 1000),
                new TripleRule(2, 200),
                new TripleRule(3, 300),
                new TripleRule(4, 400),
                new TripleRule(5, 500),
                new TripleRule(6, 600)
            };
        }

        public void Roll()
        {
            for (int i = 0; i < 6; i++)
            {
                // does this mean 0 is a possible value that could be returned?
                int dieValue = Random.Next(0, 6);
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

            foreach (var rule in Rules)
            {
                score += rule.Evaluate(DiceValues);
            }

            return score;
        }
    }
}
