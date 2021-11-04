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
            Equipment = equipment;
            Experience = experience;
            Name = name;
            Wounds = wounds;
        }

        public Survivor ReceiveWound()
        {
            int wounds = Math.Min(Wounds + 1, 2);

            int newEquipmentCount = MAX_EQUIPMENT_COUNT - wounds;

            return new Survivor(
                equipment: Equipment.Take(newEquipmentCount),
                experience: Experience,
                name: Name, 
                wounds: wounds);
        }

        public Survivor AddEquipment(Equipment equipment)
        {
            int inHandEquipmentCount = Equipment.Count(e => e.Status == EquipmentStatus.IN_HAND);

            if (inHandEquipmentCount >= 2 && equipment.Status == EquipmentStatus.IN_HAND)
            {
                throw new ArgumentException("Survivor already has two equipment in hand");
            }

            if (Equipment.Count() > (MAX_EQUIPMENT_COUNT - Wounds))
            {
                throw new ArgumentException("Survivor already holding maximum equipment");
            }

            var equipmentToAdd = Equipment.Union(new[] { equipment });

            return new Survivor(
                equipment: equipmentToAdd,
                experience: Experience,
                name: Name,
                wounds: Wounds);
        }

        public Survivor KillZombie() =>
            new (equipment: Equipment,
                experience: Experience + 1,
                name: Name,
                wounds: Wounds);

        public static Survivor CreateNew(string name) => 
            new (equipment: Enumerable.Empty<Equipment>(), 
                experience: 0, 
                name: name, 
                wounds: 0);
    }
}
