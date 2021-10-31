using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Starter
{
    public class Game
    {
        public bool IsOver => !Survivors.Any(s => s.IsAlive) && Survivors.Any();
        public IEnumerable<Survivor> Survivors { get; }

        public Game() => Survivors = Enumerable.Empty<Survivor>();
    }
}
