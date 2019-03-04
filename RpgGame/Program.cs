using System;

namespace RpgGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Monster monster = new Monster();

            while (true)
            {
                Console.WriteLine($"Monster's next attack will be {monster.CalculateAttack()}.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

    }
}