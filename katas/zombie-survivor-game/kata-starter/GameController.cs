using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Starter
{
    public class GameController
    {
        public List<Survivor> Survivors { get; set; }

        public GameController() => Survivors = new List<Survivor>();

        public void AddSurvivor(Survivor survivor)
        {
            if (Survivors.Any(s => s.Name == survivor.Name))
            {
                return;
            }

            Survivors.Add(survivor);
        }

        public int GetSurvivors()
        {
            return Survivors.Count;
        }
    }
}
