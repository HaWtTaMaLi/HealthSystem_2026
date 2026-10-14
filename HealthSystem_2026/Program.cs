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
        static int livesToDeplete;

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
            //healthStatus = "Perfect Health";

            //SHIELD
            shield = 100;
            currShield = shield;

            //LIVES
            lives = 3;
            currLives = lives;
            livesToDeplete = 1;

            //Take Damage
            ShowHUD();
            TakeDamage(60);
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            TakeDamage(20);
            ShowHUD();
            TakeDamage(30);
            ShowHUD();
            TakeDamage(30);
            ShowHUD();
            TakeDamage(30);
            ShowHUD();

            //Heal
            Heal(40);
            ShowHUD();

            //Regen
            RegenShield(20);
            ShowHUD();

        }

        static void ShowHUD()
        {
            //Update status
            UpdateHealthStatus();

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

            if (currShield < 0)
            {
                //store the remaining number
                int remainingDMG = -currShield;

                //remove remainign numbers from health
                currHealth -= remainingDMG;

                //Cap the shield
                currShield = 0;

                #region You Took Damage
                Console.Write("\nyou took ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(dmg);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" damage.");
                #endregion

                if(currHealth < 0)
                {
                    Console.WriteLine("\nYou died.");
                    //dead
                    currHealth = 0;
                    isAlive = false;
                    Revive();
                }
            }
        }

        static void Heal(int hp)
        {
            //is the player alive?
            if (isAlive == false)
            {
                Console.WriteLine("\nYou can't heal the dead.");
                return;
            }

            //dont allow health to go above 100
            if (currHealth >= 100)
            {
                currHealth = health;

                #region Max Health
                Console.WriteLine("\nyour health is at max!");
                #endregion
            }

            if (currHealth < 100)
            {
                currHealth += hp;

                #region You Healed
                Console.Write("\nyou healed ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(hp);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" health.");
                #endregion

            }
        }

        static void RegenShield(int sp)
        {
            if (isAlive == false)
            {
                Console.WriteLine("\nYou can't regen the shield of the dead.");
                return;
            }

            //dont allow shield to go above 100
            if (currShield >= 100)
            {
                currShield = shield;

                #region Max Shield
                Console.WriteLine("\nyour shield is at max!");
                #endregion
            }

            if (currShield < 100)
            {
                currShield += sp;

                #region You Regenerated
                Console.Write("\nyou regenerated ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(sp);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" shield.");
                #endregion

            }
        }

        static void Revive()
        {
            //bring the dead back to life
            isAlive = true;
            currLives -= livesToDeplete;
            currHealth = health;
            currShield = shield;
            Console.WriteLine("\nYou have been revived. " + currLives + " lives left.");
        }

        static void UpdateHealthStatus()
        {
            if(currHealth == 0)
            {
                healthStatus = "Dead";
            }
            else if (currHealth < 11)
            {
                healthStatus = "Imminent danager";
            }
            else if (currHealth < 51)
            {
                healthStatus = "Badly Hurt";
            }
            else if (currHealth < 76)
            {
                healthStatus = "Hurt";
            }
            else if (currHealth < 91)
            {
                healthStatus = "Injured";
            }
            else if (currHealth < 99)
            {
                healthStatus = "Healthy";
            }
            else
            {
                healthStatus = "perfect health";
            }
        }
    }
}
