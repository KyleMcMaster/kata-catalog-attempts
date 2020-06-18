using System.Linq.Expressions;
using Ardalis.GuardClauses;
using System;
using System.Linq;

namespace Kata.Starter
{
    public class Game
    {
        public int[] DiceValues { get; protected set; } = new int[6] { 0, 0, 0, 0, 0, 0 };

        public void Roll(int[] testdata = null)
        {
            if (testdata == null)
            {
                var rnd = new Random();

                for (int i = 0; i < 6; i++)
                {
                    var dieValue = rnd.Next(0, 6);
                    DiceValues[dieValue] = DiceValues[dieValue] + 1;
                }
            }
            else
            {
                DiceValues = testdata;
            }

            // Array.Sort(DiceValues);
            // Array.Reverse(DiceValues);
        }

        public int Score()
        {

            //here's an ugly way - 
            //  List<int> indexesInvolved = new List<int>();
            //  var resultArray = DiceValues.Where((item, index) =>
            //      { 
            //          if (item >= 3) {
            //              indexesInvolved.Add(index);
            //             return true;
            //          } 
            //          else {
            //             return false;
            //          } 
            //      }
            // ).ToArray();
            // var foundIndexArray = indexesInvolved.ToArray();

            int score = 0;
            int index = Array.IndexOf(DiceValues, 3);

            switch (index)
            {
                case 2:
                    score += 300;
                    break;
                default:
                    break;
            }

            return 0;
        }
    }
}
