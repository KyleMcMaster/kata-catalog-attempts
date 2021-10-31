namespace Kata.Starter
{
    public class Equipment
    {
        public string Name { get; }
        public EquipmentStatus Status { get; }

        public Equipment(string name, EquipmentStatus status)
        {
            Name = name;
            Status = status;
        }
    }

    public class EquipmentStatus
    {
        public string Status { get; }

        private EquipmentStatus(string status)
        {
            Status = status;
        }

        public static EquipmentStatus IN_HAND = new EquipmentStatus(nameof(IN_HAND));
        public static EquipmentStatus IN_RESERVE = new EquipmentStatus(nameof(IN_RESERVE));
    }
}
