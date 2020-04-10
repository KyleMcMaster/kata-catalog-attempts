using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Starter
{
    public class Survivor
    {
        public int MaxActions { get; set; } = 3;
        public string Name { get; }
        public string Status { get; set; }
        public uint Wounds { get; protected set; }

        public int MaxEquipment { get; set; } = 5;
        private const int MAX_IN_HAND_EQUIPMENT = 2;
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();

        public Survivor(string name) => Name = name;

        public void ReceiveWound(uint numberOfWounds)
        {
            if (Status == "DEAD")
            {
                return;
            }

            Wounds += numberOfWounds;

            if (Wounds >= 2)
            {
                Status = "DEAD";
                Wounds = 2;
            }

            MaxEquipment = MaxEquipment - (int)Wounds;

            if (Equipment.Count() > MaxEquipment)
            {
                Equipment.Remove(Equipment.First());
            }
        }

        public void AddEquipment(Equipment equipmentToAdd)
        {
            if (Equipment.Count >= MaxEquipment)
            {
                throw new Exception($"Survivor can only carry up to {MaxEquipment} pieces of Equipment");
            }

            if (equipmentToAdd.Type == "InHand")
            {
                int inHandCount = Equipment.Count(e => e.Type == "InHand");

                if (inHandCount >= MAX_IN_HAND_EQUIPMENT)
                {
                    throw new Exception($"Survivor can only carry {MAX_IN_HAND_EQUIPMENT} pieces of equipment in hand");
                }
            }

            Equipment.Add(equipmentToAdd);
        }
    }
}