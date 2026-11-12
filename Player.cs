public class Player
{
    public string Name { get; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Gold { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int MaxExp { get; set; }

    public Player(string name, int maxHealth, int gold, int level, int experience)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Gold = gold;
        Level = level;
        Experience = experience;
        MaxExp = 20;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    
    public void LevelUp()
    {
        if (Experience == MaxExp){
            Level++;
            Experience = 0;
            MaxHealth += 10;
            Health = MaxHealth;
            MaxExp += 5;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}