using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Starter
{
    public class GameController
    {
        public string CurrentLevel { get; set; } = "Blue";
        public List<Survivor> Survivors { get; set; }

        public History History { get; }

        public GameController()
        {
            History = new History(DateTimeOffset.UtcNow);
            Survivors = new List<Survivor>();
        }

        public void AddSurvivor(Survivor survivor)
        {
            if (Survivors.Any(s => s.Name == survivor.Name))
            {
                return;
            }

            Survivors.Add(survivor);
            History.LogEvent(new HistoryEvent(survivor.Name, nameof(Survivor), "ADDED_TO_GAME"));
        }

        public int GetSurvivors()
        {
            return Survivors.Count;
        }

        public void KillZombie(Survivor survivor, int count = 1)
        {
            var originalLevel = survivor.CurrentLevel;

            survivor.Experience += count;

            if (survivor.Experience > 6 && survivor.Experience <= 18)
            {
                survivor.CurrentLevel = "Yellow";
            }

            if (survivor.Experience > 18 && survivor.Experience <= 42)
            {
                survivor.CurrentLevel = "Orange";
            }

            if (survivor.Experience > 42)
            {
                survivor.CurrentLevel = "Red";
                SetGameLevel();
            }

            if (originalLevel != survivor.CurrentLevel)
            {
                SetGameLevel();
            }
        }

        public void SetGameLevel()
        {
            this.CurrentLevel = Survivors.OrderByDescending(s => s.Experience)
                .Where(s => s.Status != "DEAD")
                .FirstOrDefault().CurrentLevel;
        }
    }
}
