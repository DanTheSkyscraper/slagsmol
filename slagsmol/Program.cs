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

    Console.WriteLine("What is your name?");// This is where you write the name of your character. The name will later be used in {name} thoughout the code.
    name = Console.ReadLine();

    // This is the introduction of the game.
    Console.WriteLine($"Hello {name}. Welcome to CQC battles. You will be facing a formidable opponent who is as strong as you. Good luck!");

    // This code will allow the player to input which weapon they want their character to use. .ToLower() converts every character to lower case. All weapons deal the same damage. The weapon the player chose will appear later in the code with the help of 'player_weapon'.
    Console.WriteLine("Choose your weapon. [Sword [a]/ Axe [b]/ Hammer [c]/ Spear [d]]");
    string player_weapon = Console.ReadLine().ToLower();
    if(player_weapon == "a")
    {
        Console.WriteLine("You have chosen the Sword.");
        player_weapon = "Sword";
    }
    else if(player_weapon == "b")
    {
    Console.WriteLine("You have chosen the Axe.");
    player_weapon = "Axe";
    }
    else if(player_weapon == "c")
    {
        Console.WriteLine("You have chosen the Hammer.");
        player_weapon = "Hammer";
    }
    else
    {
        Console.WriteLine("You have chosen the Spear.");
        player_weapon = "Spear";
    }


    // This code randomizes a number between 0 and 2. This is with the help of 'generator.Next(3);'. 'int result1' uses the number chosen to decide which of the three names 'enemyAI' is going to have. The name of your characters opponent will appear later on in the code with the help of 'enemyAI_name'.
    // If the number is 0, the name will be Mordred. If the number is 1, the name will be Crimson. If the number is 2, the name will be Strider. 
    string enemyAI_name;
    int result1 = generator.Next(3);
    if(result1 == 0)
    {
        Console.WriteLine("The name of your enemy is 'Mordred'");
        enemyAI_name = "Mordred";
    }
    else if(result1 == 1)
    {
        Console.WriteLine("The name of your enemy is 'Crimson'");
        enemyAI_name = "Crimson";
    }
    else
    {
        Console.WriteLine("The name of your enemy is 'Strider'");
        enemyAI_name = "Strider";
    }

    // This code randomizes a number between 0 and 3. This is with the help of 'generator.Next(4);'. 'int result2' uses the number chosen to decide which of the four weapons 'enemyAI' is going to have. The weapon your characters opponent will choose will appear later on in the code with the help of 'enemyAI_weapon'.
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
             [  ~]                     [-  ]
          {'''   '''}               {'''   '''}
          [ [     ] ]               [ [     ] ] 
          [ [_____] ]               [ [_____] ]
          [_[ ___ ]_]               [_[ ___ ]_]
            [ ] [ ]                   [ ] [ ]
            [_] [_]                   [_] [_]

    "); // Above is ASCII art of the two characters.

    // The way this while-loop works is that as long as the health of the player AND the AI hasn't reached 0, the game will continue. The code within the while-loop will repeat until one or both of them has their health reach 0.
    while(player_health > 0 && enemyAI_health > 0)
    {
        Console.WriteLine("A NEW ROUND HAS STARTED!"); // This indicates that a new round has started.
        Console.WriteLine($"Health [{name}]: {player_health} hp   ---   Health [{enemyAI_name}]: {enemyAI_health} hp"); // With the help of 'name' and 'enemyAI_name', as well as 'player_health' and 'enemyAI_health', this line of code will repeat each round to show how much of their health is remaining.
        
        Console.WriteLine("-------------------------");
        Console.WriteLine("It is now your turn to attack!");
        Console.WriteLine($"You attack the enemy with your {player_weapon}!"); // The code from line 111 to 117, and then from 119 to 125, shows the weapons the players character and the enemyAI have chosen to attack each other with. This code will also randomize how much damage they deal with the help of 'generator.Next(weaponMinDamage, weaponMaxDamage);', which randomizes a number between 0 to 20, with 0 being the minimum number and 20 being the maximum number.
        int player_damage = generator.Next(weaponMinDamage, weaponMaxDamage); 
        Console.WriteLine("'Argh!'");
        enemyAI_health -= player_damage; // This code (line 115 and line 123) will subtract the health of the player and enemyAI with the damage they deal to each other.
        enemyAI_health = Math.Max(0, enemyAI_health); // 'Math.Max' is a Math class method used to return the larger of two specified numbers. In this code, 'enemyAI_health = Math.Max(0, enemyAI_health);' will not return 0, but 'enemyAI_health', which is the health of the enemyAI and larger of the two numbers.
        Console.WriteLine($"You strike your opponent and deal {player_damage} damage to {enemyAI_name}.");

        Console.WriteLine($"It is now {enemyAI_name}s turn to attack!");
        Console.WriteLine($"{enemyAI_name} attacks you with their {enemyAI_weapon}!"); // This is the same as the code above, just that it is the code that shows which weapon 'enemyAI' uses, how much damage they deal to the player, and subtracts that damage from the players health. 
        int enemyAI_damage = generator.Next(weaponMinDamage, weaponMaxDamage); // For more info, see comments on line 112 to 117.
        Console.WriteLine("'Ouch!'");
        player_health -= enemyAI_damage;
        player_health = Math.Max(0, player_health);
        Console.WriteLine($"{enemyAI_name} strikes with their weapon and deals {enemyAI_damage} damage to you.");
        Console.WriteLine("|");
    }
    
    Console.WriteLine("//The battle is over. The dust has settled.//"); // This indicates that the battles is over.
    Console.WriteLine("//Who shall be the one to remain standing?//");
    Console.WriteLine("...");

    if(player_health == 0) // Depending on the health of the player and the enemyAI, the code from line 133 to 151 will show different things. 
    {
        Console.WriteLine($"{enemyAI_name} has defeated you! {enemyAI_name} wins!"); // If the health of the player reaches 0, this code will declare enemyAI the winner.
        Console.WriteLine("'Better luck next time, buddy.'");
    }
    else if(enemyAI_health == 0) // If the health of enemyAI reaches 0, this code will declare the player the winner.
    {
        Console.WriteLine($"{name} has defeated {enemyAI_name}. {name} wins!");
        Console.WriteLine("...");
        Console.WriteLine("**Your friends rush over to you as you triumphantly stand there, cheering:**");
        for(int i = 0; i < 3; i++) // This will run a for-loop in order to get the friends of the player to cheer for them 3 times when they win.
        {
            Console.WriteLine("'Hip Hip Hooray!'");
        }
    }
    else
    {
        Console.WriteLine("Both fighters are out! It's a draw!"); // If the health of the player and the enemyAI reaches 0, this will tell you that it's a draw. 
    }


    Console.WriteLine("Do you wish to play again? [y/n]"); // This is the end of the while-loop. As mentioned on line 3, this Console.WriteLine will give you the option to choose whether you want to restart the game or not. If 'y' is pressed, you start again from line 5. If you press 'n', you will exit the game.
    again = Console.ReadLine();
}
Console.ReadLine();
