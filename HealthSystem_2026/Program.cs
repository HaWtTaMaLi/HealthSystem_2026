using System;

namespace HealthSystem_2026
{
    internal class Program
    {
        static int health; //Default health
        static int currHealth; //Players current health
        static string healthStatus; //The status of the players health

        static void Main()
        {
            health = 100;
            currHealth = health;
            healthStatus = "Perfect Health";

            ShowHUD();
            TakeDamage(20);
            ShowHUD();
        }

        static void ShowHUD()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n--- HUD ---");

            #region Health
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
            currHealth -= dmg;

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
