using System;

namespace RpgGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Hero hero = new Hero();
            Console.WriteLine(hero.DescribeMe());
            Console.ReadKey();

            Monster monster = new Monster();
            Console.WriteLine(monster.DescribeMe());
            Console.ReadKey();

            Weapon weapon = new Weapon();
            Console.WriteLine(weapon.DescribeMe());
            Console.ReadKey();

            Potion potion = new Potion();
            Console.WriteLine(potion.DescribeMe());
            Console.ReadKey();
        }

    }
}