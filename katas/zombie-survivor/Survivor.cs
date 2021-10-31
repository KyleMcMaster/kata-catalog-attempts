using System;

namespace Kata.Starter
{
    public class Survivor
    {
        private const int MAX_ACTIONS_PER_TURN = 3;
        public int ActionCount => Math.Max(MAX_ACTIONS_PER_TURN - Wounds, 0);
        public bool IsAlive => Wounds < 2;
        public string Name { get; }
        public int Wounds { get; }

        public Survivor(string name)
        {
            Name = name;
            Wounds = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="wounds"></param>
        private Survivor(string name, int wounds)
        {
            Name = name;
            Wounds = wounds;
        }

        public Survivor ReceiveWound()
        {
            int wounds = Math.Min(Wounds + 1, 2);

            return new Survivor(Name, wounds);
        }
    }
}
