// The game begins here.
string again = "y";
while (again == "y") // the while-loop makes it so that the game restarts if you press 'y'. Everything resets when 'y' is pressed, like names, weapon choices and health. If both characters took damage by the time 'y' is pressed, their health is restored back to 100. This is done by putting the code for the entire game within the while-loop.
{
    string name;
    int weaponMinDamage = 0;     // All integers here make it so that the minimum damage that kan be done is 0 damage, while the maximum amount of damage that can be dealt is 20 damage.
    int weaponMaxDamage = 20;

    int player_health = 100; // These integers make it so that both fighters have 100 health.
    int enemyAI_health = 100;

    Random generator = new Random(); // Random generator makes it so that depending on the number that is written, like 3, Random generator will randomly choose a number between 0 and 2. This is used when the enemyAI receives their name and weapon. It is also used when they deal damage to each other in order to randomize a damage number between 0 and 20.

    Console.WriteLine("What is your name?"); // This is where you write the name of your character. The name will later be used in {name} thoughout the code.
    name = Console.ReadLine();

    // This is the introduction of the game.
    Console.WriteLine($"Hello {name}. Welcome to CQC battles. You will be facing a formidable opponent who is as strong as you. Good luck!");
    
    Console.WriteLine("Choose your weapon. [Sword / Axe / Hammer / Spear]");
    string player_weapon = Console.ReadLine().ToLower();
    if(player_weapon == "sword")
    {
        Console.WriteLine("You have chosen the Sword.");
        player_weapon = "Sword";
    }
    else if(player_weapon == "axe")
    {
    Console.WriteLine("You have chosen the Axe.");
    player_weapon = "Axe";
    }
    else if(player_weapon == "hammer")
    {
        Console.WriteLine("You have chosen the Hammer.");
        player_weapon = "Hammer";
    }
    else
    {
        Console.WriteLine("You have chosen the Spear.");
        player_weapon = "Spear";
    }



    string enemyAI_name;
    int result1 = generator.Next(3);
    if(result1 == 0)
    {
        Console.WriteLine("The name of your enemy is Mordred.");
        enemyAI_name = "Mordred";
    }
    else if(result1 == 1)
    {
        Console.WriteLine("The name of your enemy is Crimson");
        enemyAI_name = "Crimson";
    }
    else
    {
        Console.WriteLine("The name of your enemy is Strider");
        enemyAI_name = "Strider";
    }


    string enemyAI_weapon;
    int result2 = generator.Next(4);
    
    if(result2 == 0)
    {
        Console.WriteLine($"{enemyAI_name} has chosen a Sword.");
        enemyAI_weapon = "Sword";
    }
    else if(result2 == 1)
    {
        Console.WriteLine($"{enemyAI_name} has chosen a Axe.");
        enemyAI_weapon = "Axe";
    }
    else if(result2 == 2)
    {
        Console.WriteLine($"{enemyAI_name} has chosen a Hammer");
        enemyAI_weapon = "Hammer";
    }
    else
    {
        Console.WriteLine($"{enemyAI_name} has chosen a Spear");
        enemyAI_weapon = "Spear";
    }


    Console.WriteLine(@"
             _____                     _____
             [ '']                     ['' ]
             [  -]                     [-  ]
          £'''   '''?               £'''   '''?
          [ [     ] ]               [ [     ] ]
          [ [     ] ]               [ [     ] ]
          [_[ ___ ]_]               [_[ ___ ]_]
            [ ] [ ]                   [ ] [ ]
            [_] [_]                   [_] [_]

    ");

    while(player_health > 0 && enemyAI_health > 0)
    {
        Console.WriteLine("A NEW ROUND HAS STARTED!");
        Console.WriteLine($"Health [{name}]: {player_health}   ---   Health [{enemyAI_name}]: {enemyAI_health}]");
        
        Console.WriteLine($"You attack the enemy with your {player_weapon}!");
        int player_damage = generator.Next(weaponMinDamage, weaponMaxDamage);
        enemyAI_health -= player_damage;
        enemyAI_health = Math.Max(0, enemyAI_health);
        Console.WriteLine($"You deal {player_damage} damage to {enemyAI_name}.");


        Console.WriteLine($"{enemyAI_name} attacks you with {enemyAI_weapon}!");
        int enemyAI_damage = generator.Next(weaponMinDamage, weaponMaxDamage);
        player_health -= enemyAI_damage;
        player_health = Math.Max(0, player_health);
        Console.WriteLine($"{enemyAI_name} deals {enemyAI_damage} damage to you.");
    }
    
    Console.WriteLine("//The battle is over. The dust has settled.//");

    if(player_health == 0)
    {
        Console.WriteLine($"{enemyAI_name} has defeated you! {enemyAI_name} wins!");
        Console.WriteLine("'Better luck next time, buddy.'");
    }
    else if(enemyAI_health == 0)
    {
        Console.WriteLine($"{name} has defeated {enemyAI_name}. {name} wins!");
        Console.WriteLine("...");
        Console.WriteLine("**Your friends rush over to you as you triumphantly stand there, cheering:**");
        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("'Hip Hip Hooray!'");
        }
    }
    else
    {
        Console.WriteLine("Both fighters are out! It's a draw!");
    }


    Console.WriteLine("Do you wish to play again? [y/n]");
    again = Console.ReadLine();
}
Console.ReadLine();
