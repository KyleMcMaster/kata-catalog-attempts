namespace RPGCombat
{
    public class Character
    {
        public int Health;
        public int Level;
        public bool IsAlive;

        public Character(int health, int level, bool isAlive)
        {
            Health = health;
            Level = level;
            IsAlive = isAlive;
        }

        public void TakeDamage(int damage)
        {
            if (damage > Health)
            {
                Health = 0;
                IsAlive = false;
            }
            else
            {
                Health -= damage;
            }
        }

        public void Heal()
        {
            if (IsAlive)
            {
                Health = 1000;
            }
        }
    }
}
