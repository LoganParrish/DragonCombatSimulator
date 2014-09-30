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

            Console.WindowHeight = 50;
            int width = Console.WindowWidth * 2;
            Console.WindowWidth = width;

            DragonCombatSim();

            string answer = Console.ReadLine();

            ThanksForPlaying();
           

            


            Console.ReadKey();
        }
        static void DragonCombatSim()
        {
            


            Console.WriteLine(@" _____ ______  ___   _   _  _   ___   __ ______ _____ _____  _   _ _____ ___________   _____  _   __ __    ___ 
|  __ \| ___ \/ _ \ | \ | || \ | \ \ / / |  ___|_   _|  __ \| | | |_   _|  ___| ___ \ / __  \| | / //  |  /   |
| |  \/| |_/ / /_\ \|  \| ||  \| |\ V /  | |_    | | | |  \/| |_| | | | | |__ | |_/ / `' / /'| |/ / `| | / /| |
| | __ |    /|  _  || . ` || . ` | \ /   |  _|   | | | | __ |  _  | | | |  __||    /    / /  |    \  | |/ /_| |
| |_\ \| |\ \| | | || |\  || |\  | | |   | |    _| |_| |_\ \| | | | | | | |___| |\ \  ./ /___| |\  \_| |\___  |
 \____/\_| \_\_| |_/\_| \_/\_| \_/ \_/   \_|    \___/ \____/\_| |_/ \_/ \____/\_| \_| \_____/\_| \_/\___/   |_/
                                                                                            
                   
                                                                                                               ");

            Console.WriteLine(@"Your name is Dangerous Dan. A man with a multiple personality complex and a habit of unintentionally causing self harm.
You've just managed to escape after robbing your local drug store. 75 year old Mavis Jenkins didn't stand a chance against you. 
Ha. Old people go down so easily. You're running down the street and glance over your shoulder to see none other than Mavis Jekins making a beeline toward you. 
Her walker lies upon the ground, as her amazingly toned legs sprint after you. You have a backpack full of Vicodin, a grocery basket full of shower loofahs, 
and one mean ass spanking hand. You decide that you can take her.

You stand firmly in the street. Mavis coming toward you, her perm bouncing in the wind, the smell of mothballs becoming stronger over time. 

You shut your eyes and think about how this is going to unfold.

Alright, Dan. You have...
1) A mean spanking hand that can spank Mavis for 20 - 32 damage, but you're only 70% accurate. If you're lucky, you may also land a critical hit.
2) 3 shower loofahs you can throw at her, and always hit, that do 0 - 40 damage.
3) A backpack full of Vicodin that you can use to heal yourself for 10 - 40 HP. But be careful not to overdose. I think there was something funny in one of the bottles...

Use 1, 2, and 3, respectively to attack.

Press any key to continue...
");
            Console.ReadKey();
            Console.Clear();
            Random rng = new Random();

            //your life
            int playerHP = 100;
            //enemy life
            int enemyHP = 200;
            //how many loofahs you can throw
            int loofaCount = 3;
            //if healCount ever hits 6, you overdose.
            int healCount = 0;
            //She stabs you with her insulin needle and you take 5 damage every turn. (everytime she stabs you. so if she stabs you twice, 10 damage)
            int insulinPoison = 0;
            //to keep the while loop running for the first gamemode.
            bool won = false;

            int slapCount = 0;

            int accuracyMain = 70;

            
            

            while (!won)
            {
                
                //Conditional stuff that only happens if other stuff happens like poison that has to go before death stuff
                playerHP = playerHP - insulinPoison;
                
                
                //conditions for losing / winning
                if (playerHP <= 0 && enemyHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Somehow you managed to kill eachother. Smooth move. Your bodies lay lifeless next to eachother." + "\n\n\n\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (healCount > 3) 
                {
                    Console.Clear();
                    Console.WriteLine(@"You take too much Vicodin and OD like a dip." + "\n\n\n\n\n\n");
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
                    Console.WriteLine("\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (enemyHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You managed to obliterate Mavis! Serves her right for smelling like cough drops and unwashed wrinkle folds." + "\n\n\n\n\n\n");
                    //Console.WriteLine("\n\n\n You brave soul. Do you dare progress to level 2, where the grandmothers are harder, better, faster, and stronger? Enter 'yes' to continue");
                    AddHighScore(slapCount);
                    DisplayHighScore();
                    Console.ReadKey();
                    won = true;
                    break;
                }
               


                //Player HUD showing current accuracy, poison damage per turn, and HP.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n\n\n\n____________________________________________________________________________________________");
                Console.ResetColor();
                Console.WriteLine("Health Meter : " + playerHP + " / 100" + "                                          " + "Boss Health : " + enemyHP + " / 200");
                Console.WriteLine("                             Current mainhand accuracy : " + accuracyMain + "%");
                Console.WriteLine("                                  Loofahs remaining : " + loofaCount);
                
                //handy conditional counter if you're poisoned
                if (insulinPoison > 0)
                {
                    Console.WriteLine("              \n               ================ Poison Damage Per Turn: " + insulinPoison + "================");
                }
                
                //Reminder what to press for what during the game
                Console.WriteLine("\n\n\nPress 1 to spank Mavis, 2 to throw a loofah at her, and 3 to get drugged up to heal yourself.");

                //enemy attack range
                int enemyAttack = rng.Next(10, 23);

                //input == so and so attack
                string attack = Console.ReadLine();

                int trueAttack = int.Parse(attack);

                //if 1, slap mavis
                if (trueAttack == 1 && rng.Next(0, 21) == 20)
                {
                    Console.Clear();
                    int attack1 = rng.Next(20, 33) * 2;
                    Console.WriteLine("You landed a *CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;
                    slapCount++;
                }
                else if (trueAttack == 1 && rng.Next(0, 21) == 10 || rng.Next(0, 21) == 15)
                {
                    Console.Clear();
                    int attack1 = Convert.ToInt32(rng.Next(20, 33) * 1.2);
                    Console.WriteLine("You landed a *MINI CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;
                    slapCount++;
                }
                else if (trueAttack == 1)
                {
                    if (rng.Next(0, 101) <= accuracyMain)
                    {
                        int attack1 = rng.Next(18, 33);
                        Console.Clear();
                        Console.WriteLine("You hit Mavis square on the butt and deal " + attack1  + " damage.");
                        enemyHP = enemyHP - attack1;
                        slapCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You prove your father right, and fail. You missed.");
                    }
                }

                //if 2, throw a loofah & conditions
                if (trueAttack == 2 && loofaCount > 0)
                {
                    int attack2 = rng.Next(1, 41);

                    Console.Clear();

                    loofaCount--;
                    Console.WriteLine("You pelt Mavis with a loofah and deal " + attack2 + " damage.");
                    enemyHP = enemyHP - attack2;
                }
                else if (trueAttack == 2 && loofaCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You tried throwing a loofah you didn't have and Mavis gets a free shot!");
                }

                //if 3, Vicodin conditions
                if (trueAttack == 3 && rng.Next(0, 16) == 15)
                {
                    Console.Clear();
                    Console.WriteLine(@"The pill you take was actually freebase cocaine smuggled in by the Mexican Drug Cartel!
You gain an immediate 100 health boost and gain immunity to an extra pill.");
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

                //if user inputs a number that the system does not recognize
                if (trueAttack != 1 && trueAttack != 2 && trueAttack != 3)
                {
                    Console.Clear();
                    Console.WriteLine("You try using something you don't even have, dumb ass. Mavis gets a free shot.");
                }

                //Mavis' attacks; first being to lower accuracy by 10%
                if (rng.Next(0, 15) == 1)
                {
                    Console.WriteLine("Mavis lets her cougar advances overcome her, and touches you with her pruny hands. Your accuracy is lowered by 10%.");
                    accuracyMain = accuracyMain - 10;
                }
                //insulin poisoning
                else if (rng.Next(0, 21) == 20)
                {
                    Console.WriteLine(@"Instead of hitting you, Mavis stabs you with her insulin needle. 
You will take 5 damage every turn for each time she stabs you!");
                    insulinPoison = insulinPoison + 5;
                }
                //regular hit
                else if (rng.Next(0, 101) < 80)
                {
                    playerHP = playerHP - enemyAttack;
                    Console.WriteLine("Mavis hits you for " + enemyAttack + " damage. She hits like a girl.");
                }
                //she misses
                else
                {
                    Console.WriteLine("Mavis' cataracts sets in, and she misses you.");
                }                 
            }            
        }
        static void DragonCombatSimLevel2()
        {

            MavisFighter();


            Console.WriteLine(@"You start to walk away when out of the corner of your eye, you see a movement. Mavis is getting up. 
She reaches into her purse and pulls out two small red pills. Oh no. It's her arthritis medication. She tosses them into her mouth and you can 
see the fire build in her eyes. She's rearing for battle. She flexes once her shirt explodes from her body leaving only very dangly old woman parts. 
Gross. You almost have half a mind to run away at the thought of her getting close to you with her swinging pendulums of death and wrinkles hanging from her chest, 
but you decide against it.

Let's do this, I guess.

Mavis is 2.5x stronger than before, you can take 2 extra Vicodin, have 3 extra Loofahs, a bit of extra health, and you have an increased chance at landing a critical hit. 

Good luck.
");
            Console.ReadKey();
            Console.Clear();
            Random rng = new Random();

            //your life
            int playerHP = 160;
            //enemy life
            int enemyHP = 450;
            //how many loofahs you can throw
            int loofaCount = 6;
            //if healCount ever hits 6, you overdose.
            int healCount = 0;
            //She stabs you with her insulin needle and you take 5 damage every turn. (everytime she stabs you. so if she stabs you twice, 10 damage)
            int insulinPoison = 0;
            //to keep the while loop running for the first gamemode.
            bool won = false;

            int accuracyMain = 70;




            while (!won)
            {

                //Conditional stuff that only happens if other stuff happens like poison that has to go before death stuff
                playerHP = playerHP - insulinPoison;


                //conditions for losing / winning
                if (playerHP <= 0 && enemyHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(@"Somehow you managed to kill eachother. Smooth move. Your bodies lay lifeless next to eachother. Better luck next time,
starting at Level 1." + "\n\n\n\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (healCount > 5)
                {
                    Console.Clear();
                    Console.WriteLine(@"You take too much Vicodin and OD like a dip.Better luck next time,
starting at Level 1." + "\n\n\n\n\n\n" + "\n\n\n\n\n\n");
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
it into your lifeless mouth. Better luck next time, starting at Level 1." + "\n\n\n\n\n\n");
                    Console.WriteLine("\n\n\n");
                    GameOver();
                    won = true;
                    break;
                }
                if (enemyHP <= 0)
                {
                    Console.Clear();
                    Jesus();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("You defeated Mavis MK.2! Congratulations!... until her husband comes after you." + "\n\n\n\n\n\n");
                    Console.WriteLine("\n\n\n");
                    ThanksForPlaying();
                    won = true;
                    break;
                }





                Console.WriteLine("\n\n\n\n\n____________________________________________________________________________________________");
                Console.WriteLine("Health Meter : " + playerHP + " / 160" + "                                          " + "Boss Health : " + enemyHP + " / 450");
                Console.WriteLine("                             Current mainhand accuracy : " + accuracyMain + "%");
                Console.WriteLine("                                  Loofahs remaining : " + loofaCount);
                //handy conditional counter if you're poisoned
                if (insulinPoison > 0)
                {
                    Console.WriteLine("              \n               ================ Poison Damage Per Turn: " + insulinPoison + "================");
                }

                Console.WriteLine("\n\n\nPress 1 to spank Mavis, 2 to throw a loofah at her, and 3 to get drugged up to heal yourself.");

                int enemyAttack = rng.Next(10, 60);

                string attack = Console.ReadLine();

                int trueAttack = int.Parse(attack);


                if (trueAttack == 1 && rng.Next(0, 11) == 10)
                {
                    Console.Clear();
                    int attack1 = rng.Next(20, 36) * 2;
                    Console.WriteLine("You landed a *CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;

                }
                else if (trueAttack == 1 && rng.Next(0, 11) == 10 || rng.Next(0, 11) == 5)
                {
                    Console.Clear();
                    int attack1 = Convert.ToInt32(rng.Next(20, 36) * 1.2);
                    Console.WriteLine("You landed a *MINI CRIT* and dealt " + attack1 + " damage!!!");
                    enemyHP = enemyHP - attack1;
                }
                else if (trueAttack == 1)
                {
                    if (rng.Next(0, 101) <= accuracyMain)
                    {
                        int attack1 = rng.Next(20, 36);
                        Console.Clear();
                        Console.WriteLine("You hit Mavis square on the butt and deal " + attack1 + " damage.");
                        enemyHP = enemyHP - attack1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You prove your father right, and fail. You missed.");
                    }
                }
                if (trueAttack == 2 && loofaCount > 0)
                {
                    int attack2 = rng.Next(1, 41);

                    Console.Clear();

                    loofaCount--;
                    Console.WriteLine("You pelt Mavis with a loofah and deal " + attack2 + " damage.");
                    enemyHP = enemyHP - attack2;
                }
                else if (trueAttack == 2 && loofaCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You tried throwing a loofah you didn't have and Mavis gets a free shot!");
                }
                if (trueAttack == 3 && rng.Next(0, 16) == 15)
                {
                    Console.Clear();
                    Console.WriteLine(@"The pill you take was actually freebase cocaine smuggled in by the Mexican Drug Cartel!
You gain an immediate 100 health boost and gain immunity to an extra pill.");
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
                if (rng.Next(0, 15) == 1)
                {
                    Console.WriteLine("Mavis makes a move on you, trying to feel you up with her pruny hands. Your accuracy is lowered by 10%.");
                    accuracyMain = accuracyMain - 10;
                }
                else if (rng.Next(1, 16) == 15)
                {
                    Console.WriteLine(@"Instead of hitting you, Mavis stabs you with her insulin needle. 
You will take 5 damage every turn for each time she stabs you!");
                    insulinPoison = insulinPoison + 5;
                }
                else if (rng.Next(0, 101) < 80)
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
        static void GrannyFighter()
        {
            Console.WriteLine(@" _____ ______  ___   _   _  _   ___   __ ______ _____ _____  _   _ _____ ___________   _____  _   __ __    ___ 
|  __ \| ___ \/ _ \ | \ | || \ | \ \ / / |  ___|_   _|  __ \| | | |_   _|  ___| ___ \ / __  \| | / //  |  /   |
| |  \/| |_/ / /_\ \|  \| ||  \| |\ V /  | |_    | | | |  \/| |_| | | | | |__ | |_/ / `' / /'| |/ / `| | / /| |
| | __ |    /|  _  || . ` || . ` | \ /   |  _|   | | | | __ |  _  | | | |  __||    /    / /  |    \  | |/ /_| |
| |_\ \| |\ \| | | || |\  || |\  | | |   | |    _| |_| |_\ \| | | | | | | |___| |\ \  ./ /___| |\  \_| |\___  |
 \____/\_| \_\_| |_/\_| \_/\_| \_/ \_/   \_|    \___/ \____/\_| |_/ \_/ \____/\_| \_| \_____/\_| \_/\___/   |_/
                                                                                                               
                                                                                                               " + "\n\n");
        }
        static void ToBeContinued()
        {
            Console.WriteLine(@" _____ _____  ______ _____   _____ _____ _   _ _____ _____ _   _ _   _ ___________ 
|_   _|  _  | | ___ \  ___| /  __ \  _  | \ | |_   _|_   _| \ | | | | |  ___|  _  \
  | | | | | | | |_/ / |__   | /  \/ | | |  \| | | |   | | |  \| | | | | |__ | | | |
  | | | | | | | ___ \  __|  | |   | | | | . ` | | |   | | | . ` | | | |  __|| | | |
  | | \ \_/ / | |_/ / |___  | \__/\ \_/ / |\  | | |  _| |_| |\  | |_| | |___| |/ / 
  \_/  \___/  \____/\____/   \____/\___/\_| \_/ \_/  \___/\_| \_/\___/\____/|___/  
                                                                                   
                                                                                   ");
        }
        static void MavisFighter()
        {
            Console.WriteLine(@"___  ___  ___  _   _ _____ _____  ___  ___ _   __  _____  ______ _____ _____  _   _ _____ ___________ 
|  \/  | / _ \| | | |_   _/  ___| |  \/  || | / / / __  \ |  ___|_   _|  __ \| | | |_   _|  ___| ___ \
| .  . |/ /_\ \ | | | | | \ `--.  | .  . || |/ /  `' / /' | |_    | | | |  \/| |_| | | | | |__ | |_/ /
| |\/| ||  _  | | | | | |  `--. \ | |\/| ||    \    / /   |  _|   | | | | __ |  _  | | | |  __||    / 
| |  | || | | \ \_/ /_| |_/\__/ / | |  | || |\  \_./ /___ | |    _| |_| |_\ \| | | | | | | |___| |\ \ 
\_|  |_/\_| |_/\___/ \___/\____/  \_|  |_/\_| \_(_)_____/ \_|    \___/ \____/\_| |_/ \_/ \____/\_| \_|
                                                                                                      
                                                                                                          


");
        }
        static void Jesus()
        {
            Console.WriteLine(@"   ___   _____   _____   _   _   _____        __   __  _____   _   _      _    _   _____   _   _ ___  
  |_  | |  ___| /  ___| | | | | /  ___|       \ \ / / |  _  | | | | |    | |  | | |  _  | | \ | |__ \ 
    | | | |__   \ `--.  | | | | \ `--.         \ V /  | | | | | | | |    | |  | | | | | | |  \| |  ) |
    | | |  __|   `--. \ | | | |  `--. \         \ /   | | | | | | | |    | |/\| | | | | | | . ` | / / 
/\__/ / | |___  /\__/ / | |_| | /\__/ /  _      | |   \ \_/ / | |_| |    \  /\  / \ \_/ / | |\  ||_|  
\____/  \____/  \____/   \___/  \____/  ( )     \_/    \___/   \___/      \/  \/   \___/  \_| \_/(_)  
                                        |/                                                            
                                                                                                      ");
        }
        static void AddHighScore(int playerScore)
        {
            Console.Clear();
            Console.WriteLine("Add your name to display how many times you spanked Mavis to the highscores: ");
            string playerName = Console.ReadLine();

            LoganEntities1 db = new LoganEntities1();

            HighScore newHighScore = new HighScore();

            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Name = playerName;
            newHighScore.Game = "GrannyFighter2K14";
            newHighScore.Score = playerScore;

            db.HighScores.Add(newHighScore);

            db.SaveChanges();
        }
        static void DisplayHighScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================== HIGH SCORES ====================");
            Console.WriteLine("=====================================================\n\n");
            Console.ResetColor();

            LoganEntities1 db = new LoganEntities1();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "GrannyFighter2K14").OrderByDescending(x => x.Score).Take(10).ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}. {1} - Only {2} spanks to put that lady in her place - {3}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score, highScore.DateCreated.Value.ToShortDateString());
                Console.ResetColor();
            }
        }
    }
}
