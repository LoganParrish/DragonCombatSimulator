using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonCombatSim();
            Console.ReadKey();
        }
        static void DragonCombatSim()
        {
            Console.WindowHeight = 50;
            int width = Console.WindowWidth * 2;
            Console.WindowWidth = width;


            Console.WriteLine(@" ______   _______  _____  _____   ______    _______  _____  _____  ____  _____  
|_   _ `.|_   __ \|_   _||_   _|.' ___  |  |_   __ \|_   _||_   _||_   \|_   _| 
  | | `. \ | |__) | | |    | | / .'   \_|    | |__) | | |    | |    |   \ | |   
  | |  | | |  __ /  | '    ' | | |   ____    |  __ /  | '    ' |    | |\ \| |   
 _| |_.' /_| |  \ \_ \ \__/ /  \ `.___]  |  _| |  \ \_ \ \__/ /    _| |_\   |_  
|______.'|____| |___| `.__.'    `._____.'  |____| |___| `.__.'    |_____|\____| 
                                                                                " + "\n\n");

            Console.WriteLine(@"Your name is Dangerous Dan. A man with a multiple personality complex and a habit of unintentionally causing self harm.
You've just managed to escape after robbing your local drug store. 75 year old Mavis Jenkins didn't stand a chance against you. 
Ha. Old people go down so easily. You're running down the street and glance over your shoulder to see none other than Mavis Jekins making a beeline toward you. 
Her walker lies upon the ground, as her amazingly toned legs sprint after you. You have a backpack full of Vicodin, a grocery basket full of shower loofahs, 
and one mean ass spanking hand. You decide that you can take her.

You stand firmly in the street. Mavis coming toward you, her perm bouncing in the wind, the smell of mothballs becoming stronger over time. 

You shut your eyes and think about how this is going to unfold.

Alright, Dan. You have...
1) A mean spanking hand that can spank Mavis for 20 - 35 damage, but you're only 70% accurate. If you're lucky, you may also land a critical hit.
2) 3 shower loofahs you can throw at her, and always hit, that do 0 - 40 damage.
3) A backpack full of Vicodin that you can use to heal yourself for 10 - 40 HP. But be careful not to overdose. I think there was something funny in one of the bottles...

Use 1, 2, and 3, respectively to attack.

Press any key to continue...
");
            Console.ReadKey();
            Console.Clear();

            int playerHP = 100;
            int enemyHP = 300;
            int loofaCount = 3;
            int buttslap = 0;
            //if healCount > 10, die instantly, you overdosed.
            int healCount = 0;
            bool won = false;

            Random rng = new Random();

            while (!won)
            {
                if (healCount >= 6)
                {
                    Console.Clear();
                    Console.WriteLine(@"You take too much Vicodin and OD like a dip." + "\n\n\n\n\n\n");
                    ThanksForPlaying();
                    Console.WriteLine("\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (playerHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Oh dear, you're dead! \n\n\n");
                    Console.WriteLine(@"Mavis takes back all of her drugs and picks up the scattered loofahs. She removes one of the tennis balls from her walker and shoves
it into your lifeless mouth." + "\n\n\n\n\n\n");
                    ThanksForPlaying();
                    Console.WriteLine("\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (enemyHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You managed to obliterate Mavis! Serves her right for smelling like cough drops and unwashed wrinkle folds." + "\n\n\n\n\n\n");
                    ThanksForPlaying();
                    won = true;
                    break;
                }
                if (playerHP <= 0 && enemyHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Somehow you managed to kill eachother. Smooth move. Your bodies lay lifeless next to eachother." + "\n\n\n\n\n\n");
                    ThanksForPlaying();
                    GameOver();
                    won = true;
                    break;
                }


                Console.WriteLine("\n\n\n\n\n____________________________________________________________________________________");
                Console.WriteLine("Health Meter : " + playerHP + " / 100" + "            " + "Boss Health : " + enemyHP + " / 300");
                
                Console.WriteLine("\n\n\nPress 1 to spank Mavis, 2 to throw a loofa at her, and 3 to get drugged up to heal yourself.");

                int enemyAttack = rng.Next(15, 31);

                string attack = Console.ReadLine();
                int trueAttack = int.Parse(attack);


                if (trueAttack == 1 && rng.Next(0, 21) == 20)
                {
                    Console.Clear();
                    int attack1 = rng.Next(20, 36) * 2;
                    Console.WriteLine("You landed a *CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;
                }
                else if (trueAttack == 1 && rng.Next(0, 21) == 10 || rng.Next(0, 21) == 15)
                {
                    Console.Clear();
                    int attack1 = Convert.ToInt32(rng.Next(20, 36) * 1.5);
                    Console.WriteLine("You landed a *MINI CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;
                }
                else if (trueAttack == 1)
                {
                    if (rng.Next(0, 101) <= 70)
                    {
                        int attack1 = rng.Next(20, 36);
                        Console.Clear();
                        Console.WriteLine("You hit Mavis square on the butt and deal " + attack1  + " damage.");
                        enemyHP = enemyHP - attack1;
                        buttslap++;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You prove your father right, and fail. You missed.");
                    }
                }
                if (trueAttack == 2 && loofaCount > 0)
                {
                    int attack2 = rng.Next(0, 41);

                    Console.Clear();

                    loofaCount--;
                    Console.WriteLine("You pelt Mavis with a loofa and deal " + attack2 + "  damage. You now have " + loofaCount + " loofahs left.");
                    enemyHP = enemyHP - attack2;
                }
                else if (loofaCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You tried throwing a loofah you didn't have and Mavis gets a free shot!");
                }
                if (trueAttack == 3 && rng.Next(0, 16) == 15)
                {
                    Console.Clear();
                    Console.WriteLine(@"The pill you take was actually freebase cocaine smuggled in by the Mexican Cartel!
You gain an immediate 100 health boost and gain immunity to 2 more pills.");
                    playerHP = playerHP + 100;
                    healCount--;
                }
                else if (trueAttack == 3)
                {
                    Console.Clear();
                    healCount++;
                    int attack3 = rng.Next(10, 41);
                    playerHP = playerHP + attack3;
                    Console.WriteLine("You pop some pills and heal yourself for " + attack3 + " health... careful not to OD.");
                }
                if (trueAttack != 1 && trueAttack != 2 && trueAttack != 3)
                {
                    Console.Clear();
                    Console.WriteLine("You try using something you don't even have, dumb ass. Mavis gets a free shot.");
                }
                if (rng.Next(0, 101) < 80)
                {
                    playerHP = playerHP - enemyAttack;
                    Console.WriteLine("Mavis hits you for " + enemyAttack + " damage. She hits like a girl.");
                }
                else
                {
                    Console.WriteLine("Mavis' cataracts sets in, and she misses you.");
                }
               

                
            }


        }
        static void ThanksForPlaying()
        {
            Console.WriteLine(@" _____ _                 _           __                   _             _             _ 
|_   _| |               | |         / _|                 | |           (_)           | |
  | | | |__   __ _ _ __ | | _____  | |_ ___  _ __   _ __ | | __ _ _   _ _ _ __   __ _| |
  | | | '_ \ / _` | '_ \| |/ / __| |  _/ _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` | |
  | | | | | | (_| | | | |   <\__ \ | || (_) | |    | |_) | | (_| | |_| | | | | | (_| |_|
  \_/ |_| |_|\__,_|_| |_|_|\_\___/ |_| \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, (_)
                                                   | |             __/ |         __/ |  
                                                   |_|            |___/         |___/   ");
        }
        static void GameOver()
        {
            Console.WriteLine(@" _____   ___  ___  ___ _____   _____  _   _ ___________ 
|  __ \ / _ \ |  \/  ||  ___| |  _  || | | |  ___| ___ \
| |  \// /_\ \| .  . || |__   | | | || | | | |__ | |_/ /
| | __ |  _  || |\/| ||  __|  | | | || | | |  __||    / 
| |_\ \| | | || |  | || |___  \ \_/ /\ \_/ / |___| |\ \ 
 \____/\_| |_/\_|  |_/\____/   \___/  \___/\____/\_| \_|
                                                        
                                                        ");
        }
    }
}
