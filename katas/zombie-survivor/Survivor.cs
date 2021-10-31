using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Starter
{
    public class Survivor
    {
        private const int MAX_ACTIONS_PER_TURN = 3;
        private const int MAX_EQUIPMENT_COUNT = 5;
        public int ActionCount => Math.Max(MAX_ACTIONS_PER_TURN - Wounds, 0);
        public IEnumerable<Equipment> Equipment { get; }
        public int Experience { get; }
        public bool IsAlive => Wounds < 2;
        public string Name { get; }
        public int Wounds { get; }

        private Survivor(
            IEnumerable<Equipment> equipment, 
            int experience, 
            string name, 
            int wounds)
        {
            Guard.Against.OutOfRange(equipment.Count(), nameof(equipment), 0, MAX_EQUIPMENT_COUNT - Wounds);
            Guard.Against.OutOfRange(equipment.Where(e => e.Status == EquipmentStatus.IN_HAND).Count(), nameof(equipment), 0, 2);

            Equipment = equipment;
            Experience = experience;
            Name = name;
            Wounds = wounds;
        }

        public Survivor ReceiveWound()
        {
            int wounds = Math.Min(Wounds + 1, 2);

            return new Survivor(
                equipment: Equipment.Take(MAX_EQUIPMENT_COUNT-wounds),
                experience: Experience,
                name: Name, 
                wounds: wounds);
        }

        public static Survivor CreateNew(IEnumerable<Equipment> equipment, string name) => new Survivor(
            equipment: equipment, 
            experience: 0, 
            name: name, 
            wounds: 0);
    }
}
