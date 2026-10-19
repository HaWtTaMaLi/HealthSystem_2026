using System;
using System.Diagnostics;

namespace HealthSystem_2026
{
    internal class Program
    {
        //HEALTH
        static int maxHealth = 100; //Default health
        static int currHealth; //Players current health
        static string healthStatus; //The status of the players health
        
        //SHIELD
        static int maxShield = 100; //Default shield
        static int currShield; //Players current health

        //LIVES
        static int baselives = 3; //Default lives
        static int currLives; //Players current lives
        static int livesToDeplete = 1;

        //Is the player alive?
        static bool isAlive;

        static void Main()
        {
            //Unit Test Health System
            UnitTestHealhtSystem();

            //COLOUR
            Console.ForegroundColor = ConsoleColor.Gray;

            //reset stats
            ResetGame();

            //Take Damage to show health status
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

            //You Died
            TakeDamage(30);
            ShowHUD();

            //Revive
            Revive();
            ShowHUD();

            //Heal on full health
            Heal(40);
            ShowHUD();

            //Regen on full shield
            RegenShield(20);
            ShowHUD();

            //OneUp
            OneUp();
            ShowHUD();

            //OnUP on full lives
            OneUp();
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
            // currShield = 5;
            // currHealth = 100;
            // currLives = 3;
            // TakeDamage(110);

            //is the player alive?
            if (isAlive == false) 
            {
                Console.WriteLine("\nYou can't kill the dead.");
                return; 
            }

            //dmg cant be negative
            if(dmg < 0)
            {
                dmg = 0;
                Console.WriteLine("You cant deal negative damage.");
                return;
            }

            //shield takes damage first
            currShield -= dmg;

            #region You Took Damage
            Console.Write("\nyou took ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(dmg);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" damage.");
            #endregion

            //if current shield is less then 0 
            if (currShield < 0)
            {
                //store the remaining number
                int remainingDMG = -currShield;

                //remove remainign numbers from health
                currHealth -= remainingDMG;

                //Cap the shield
                currShield = 0;

                if(currHealth < 0)
                {
                    Console.WriteLine("\nYou died.");
                    //dead
                    currHealth = 0;
                    isAlive = false;
                    //Revive();
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

            //dont allow health to go above 100
            if (currHealth >= 100)
            {
                currHealth = maxHealth;

                #region Max Health
                Console.Write("\nyou tried to heal ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hp);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" health.");
                Console.WriteLine("your health is at max!");
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

            //dont allow shield to go above 100
            if (currShield >= 100)
            {
                currShield = maxShield;

                #region Max Shield
                Console.Write("\nyou tried to regen ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(sp);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" shield.");
                Console.WriteLine("your shield is at max!");
                #endregion
            }
        }

        static void Revive()
        {
            //if we already have 3 lives
            if (isAlive == true)
            {
                Console.WriteLine("\nYou can't revive those who are already alive.");
                return;
            }

            //if lives are less then or equal to 0
            if(currLives <= 0)
            {
                isAlive = false;
                return;
            }
            else
            {
                //bring the dead back to life
                isAlive = true;
                currLives -= livesToDeplete;
                currHealth = maxHealth;
                currShield = maxShield;

                #region Revive Lives
                Console.Write("\nYou have been revived. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(currLives);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" lives left.");
                #endregion
            }
        }

        static void OneUp()
        {
            if (isAlive == false)
            {
                Console.WriteLine("\nYou can't give lives to dead people.");
                return;
            }

            if (currLives >= baselives)
            {
                currLives = baselives;

                #region Max Lives
                Console.Write("\nyou tried to gain ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(livesToDeplete);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" life.");
                Console.WriteLine("your lives are at max!");
                #endregion
            }
            else
            {
                currLives += livesToDeplete;

                #region One Up life
                Console.Write("\nYou gained a life. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(currLives);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" lives left.");
                #endregion
            }
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

        static void ResetGame()
        {
            //ALIVE?
            isAlive = true;
            //HEALTH
            currHealth = maxHealth;
            //SHIELD
            currShield = maxShield;
            //LIVE
            currLives = baselives;
        }

        static void UnitTestHealhtSystem()
        {

            //TakeDamage()
            #region Take Damage

            //Shield only
            isAlive = true;
            currShield = 100;
            currHealth = 100;
            currLives = 3;
            TakeDamage(10);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 90);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            //Health only
            isAlive = true;
            currShield = 0;
            currHealth = 100;
            currLives = 3;
            TakeDamage(50);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 50);
            Debug.Assert(currLives == 3);

            //Shield and Health
            isAlive = true;
            currShield = 10;
            currHealth = 100;
            currLives = 3;
            TakeDamage(50);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 60);
            Debug.Assert(currLives == 3);

            //Health and lives
            isAlive = true;
            currShield = 0;
            currHealth = 10;
            currLives = 3;
            TakeDamage(25);

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 3);

            //Shield health and lives
            isAlive = true;
            currShield = 5;
            currHealth = 100;
            currLives = 3;
            TakeDamage(110);

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 3);

            //Negative Input
            isAlive = true;
            currShield = 50;
            currHealth = 50;
            currLives = 3;
            TakeDamage(-10);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 50);
            Debug.Assert(currHealth == 50);
            Debug.Assert(currLives == 3);

            Console.Clear();
            #endregion

            //Heal()
            #region Heal

            //Health only
            isAlive = true;
            currShield = 10;
            currHealth = 50;
            currLives = 3;
            Heal(10);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 10);
            Debug.Assert(currHealth == 60);
            Debug.Assert(currLives == 3);

            //when dead
            isAlive = false;
            currShield = 0;
            currHealth = 0;
            currLives = 3;
            Heal(10);

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 3);

            //max health
            isAlive = true;
            currShield = 10;
            currHealth = 50;
            currLives = 3;
            Heal(60);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 10);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            Console.Clear();
            #endregion

            //RegenShield()
            #region Regen shield

            //shield only
            isAlive = true;
            currShield = 10;
            currHealth = 90;
            currLives = 3;
            RegenShield(50);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 60);
            Debug.Assert(currHealth == 90);
            Debug.Assert(currLives == 3);

            //when dead
            isAlive = false;
            currShield = 0;
            currHealth = 0;
            currLives = 3;
            RegenShield(50);

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 3);

            //max shield
            isAlive = true;
            currShield = 90;
            currHealth = 100;
            currLives = 3;
            RegenShield(20);

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 100);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            Console.Clear();
            #endregion

            //Revive()
            #region Revive

            //lives shield and health
            isAlive = false;
            currShield = 0;
            currHealth = 0;
            currLives = 3;
            Revive();

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 100);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 2);

            //when alive
            isAlive = true;
            currShield = 100;
            currHealth = 100;
            currLives = 3;
            Revive();

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 100);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            //when lives are at 0
            isAlive = false;
            currShield = 0;
            currHealth = 0;
            currLives = 0;
            Revive();

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 0);

            Console.Clear();
            #endregion

            //OneUp()
            #region One Up

            //Lives only
            isAlive = true;
            currShield = 100;
            currHealth = 100;
            currLives = 2;
            OneUp();

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 100);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            //max OneUp
            isAlive = true;
            currShield = 100;
            currHealth = 100;
            currLives = 3;
            OneUp();

            Debug.Assert(isAlive == true);
            Debug.Assert(currShield == 100);
            Debug.Assert(currHealth == 100);
            Debug.Assert(currLives == 3);

            //when at 0
            isAlive = false;
            currShield = 0;
            currHealth = 0;
            currLives = 0;
            OneUp();

            Debug.Assert(isAlive == false);
            Debug.Assert(currShield == 0);
            Debug.Assert(currHealth == 0);
            Debug.Assert(currLives == 0);

            Console.Clear();
            #endregion

            //Bottom of test
            Console.WriteLine("Unit test for Health System completed.");
        }
    }
}
