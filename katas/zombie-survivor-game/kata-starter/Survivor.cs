namespace Kata.Starter
{
    public class Survivor
    {
        public int MaxActions { get; set; } = 3;
        public string Name { get; }
        public string Status { get; set; }
        public uint Wounds { get; protected set; } = 0;


        public Survivor(string name) => this.Name = name;

        public void ReceiveWound(uint numberOfWounds)
        {
            if (this.Status == "DEAD")
            {
                return;
            }

            this.Wounds += numberOfWounds;

            if (this.Wounds >= 2)
            {
                this.Status = "DEAD";
                this.Wounds = 2;
            }
        }

    }
}