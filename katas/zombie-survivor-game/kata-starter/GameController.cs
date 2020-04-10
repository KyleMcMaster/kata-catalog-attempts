using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Starter
{
    public class GameController
    {
        private List<Survivor> Survivors { get; set; }
        private int CurrentTurn { get; set; } = 1;

        public void ProcessTurn(Survivor survivor)
        {

        }

        public void ProcessAction(Survivor survivor)
        {

        }

        public void AddSurvivor(Survivor survivor) => Survivors.Add(survivor);
    }
}
