using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Starter
{
    public class Game
    {
        public Level Level => LevelCalculator.Calculate(Survivors.OrderByDescending(s => s.Experience).FirstOrDefault()?.Experience ?? default);
        public bool IsOver => !Survivors.Any(s => s.IsAlive) && Survivors.Any();
        public List<Survivor> Survivors { get; }

        public Game() => Survivors = new();

        public void AddSurvivor(Survivor survivor)
        {
            if (Survivors.Any(a => a.Name == survivor.Name))
            {
                throw new ArgumentException("Survivor Name must be unique");
            }

            Survivors.Add(survivor);
        }
    }
}
