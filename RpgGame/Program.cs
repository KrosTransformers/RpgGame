using System;

namespace RpgGame
{
    class Program
    {

        static void Main(string[] args)
        {
            bool playAgain = false;

            do
            {
                Console.Clear();

                Hero hero = new Hero();
                BattleMaster.StartCampaign(hero);

                Console.WriteLine("Play again? [Y/N]");
                playAgain = (Console.ReadLine().ToLower() == "y");
            } while (playAgain);
        }

    }
}