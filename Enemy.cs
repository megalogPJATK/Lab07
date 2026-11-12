public class Enemy
{
    public string Name { get; }
    public int Health { get; set; }
    public int Damage { get; }
    public int ExperienceGain { get; }

    public Enemy(string name, int health, int damage, int exp)
    {
        Name = name;
        Health = health;
        Damage = damage;
        ExperienceGain = exp;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

}