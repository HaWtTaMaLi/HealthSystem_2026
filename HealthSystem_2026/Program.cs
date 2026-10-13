using System;

namespace HealthSystem_2026
{
    internal class Program
    {
        //HEALTH
        static int health; //Default health
        static int currHealth; //Players current health
        static string healthStatus; //The status of the players health
        
        //SHIELD
        static int shield; //Default shield
        static int currShield; //Players current health

        //LIVES
        static int lives; //Default lives
        static int currLives; //Players current lives

        //Is the player alive?
        static bool isAlive;

        static void Main()
        {
            //COLOUR
            Console.ForegroundColor = ConsoleColor.Gray;

            //ALIVE?
            isAlive = true;

            //HEALTH
            health = 100;
            currHealth = health;
            healthStatus = "Perfect Health";

            //SHIELD
            shield = 100;
            currShield = shield;

            //LIVES
            lives = 3;
            currLives = lives;

            ShowHUD();
            TakeDamage(110);
            ShowHUD();
        }

        static void ShowHUD()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n--- HUD ---");

            #region Lives
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Lives : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(currLives);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            #endregion

            #region Shield
            Console.Write("Shield: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(currShield);
            Console.ForegroundColor = ConsoleColor.Gray;
            #endregion

            #region Health
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Health: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currHealth);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ~ ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(healthStatus);
            Console.ForegroundColor = ConsoleColor.Gray;
            #endregion

        }

        static void TakeDamage(int dmg)
        {
            //is the player alive?
            if (isAlive == false) 
            {
                Console.WriteLine("\nYou can't kill the dead.");
                return; 
            }

            currShield -= dmg;

            if (currShield <= 0)
            {
                //store the remaining number
                int remainingDMG = -currShield;
                //remove remainign numbers from health
                currHealth -= remainingDMG;
                //Cap the shield
                currShield = 0;
            }

            #region You Took Damage
            Console.Write("\nyou took ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(dmg);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" damage.");
            #endregion
        }
    }
}
