// Obiekty i walka

using System.ComponentModel.DataAnnotations;

Player player = new Player("Natalia", 100, 25, 0, 0);
Player player2 = new Player("Reigen", 100, 20, 0, 0);

List<Enemy> enemies = new List<Enemy>
{
    new Enemy("Goblin", 30, 8, 5),
    new Enemy("Nietoperz", 20, 5, 3),
    new Enemy("Ork", 70, 15, 10),
    new Enemy("Jaszczurka", 10, 5, 1),
    new Enemy("Golem", 120, 5, 20)
};

bool graDziala = true;

while(graDziala){

int numerPrzeciwnika = 1;
int maxHpEnemy = 0;

Console.WriteLine($"{player.Name} (HP {player.Health}/{player.MaxHealth}) i {player2.Name} (HP {player2.Health}/{player2.MaxHealth}) spotykają: ");

Console.WriteLine("");


foreach (Enemy enemy in enemies)
{
    Console.WriteLine($"{numerPrzeciwnika}. {enemy.Name}: {enemy.Health} HP");
    numerPrzeciwnika++;
    maxHpEnemy += enemy.Health;
}

Console.WriteLine("");

Console.WriteLine("Kogo atakujesz?");

int wybor = int.Parse(Console.ReadLine()!);

if (wybor > 1 || wybor < 5 || enemies[wybor - 1].Health > 0)
    {
        string wybranyPrzeciwnik = enemies[wybor - 1].Name;
        Console.WriteLine($"Wybrano {wybranyPrzeciwnik} do ataku.");
        
        bool wybraniePrzeciwnika = true;

            while (wybraniePrzeciwnika)
                {
                    Console.WriteLine($"{player.Name} atakuje {wybranyPrzeciwnik}.");

                    Console.WriteLine("");

                    enemies[wybor - 1].TakeDamage(12);

                    Console.WriteLine($"{wybranyPrzeciwnik} ma {enemies[wybor - 1].Health} HP.");

                    if (enemies[wybor - 1].IsAlive())
                    {
                        player.TakeDamage(enemies[wybor - 1].Damage);
                        Console.WriteLine($"{player.Name} ma {player.Health} HP.");
                    }
                    else
                    {
                        Console.WriteLine($"Przeciwnik został pokonany, dostajesz {enemies[wybor - 1].ExperienceGain} exp.");
                        player.Experience += 5;
                    }

                        wybraniePrzeciwnika = false;

                }

                if(!enemies[wybor - 1].IsAlive()){
                        enemies.Remove(enemies[wybor - 1]);
                    }
    }
    else
    {
        Console.WriteLine("Nie ma takiego przeciwnika.");
    }

if (!player.IsAlive() || !player2.IsAlive() || maxHpEnemy == 0)
    {
        graDziala = false;
        Console.WriteLine("Koniec gry.");
    }

    Console.WriteLine("");

}

