using System;

namespace RpgGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Hero hero = new Hero();
            Monster monster = new Monster();

            Console.WriteLine("Hero encounters a monster!!!");
            Console.ReadKey();

            while (true)
            {
                if (HeroAttack(hero, monster))
                {
                    break;
                }


                if (MonsterAttack(hero, monster))
                {
                    break;
                }

                PotionChance(hero, 0.25);
            }
        }

        /// <summary>
        /// Hero attacks.
        /// </summary>
        /// <param name="hero">Hero.</param>
        /// <param name="monster">Monster.</param>
        /// <returns>True, if monster is killed; otherwise false.</returns>
        private static bool HeroAttack(Hero hero, Monster monster)
        {
            int nextAttack = hero.CalculateAttack();
            monster._health = Math.Max(monster._health - nextAttack, 0);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Hero attacks for {nextAttack} HP. Monster is left with {monster._health} HP.");
            Console.ResetColor();

            if (monster._health == 0)
            {
                Console.WriteLine("Monster is dead. YAY!");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// Monster attacks.
        /// </summary>
        /// <param name="hero">Hero.</param>
        /// <param name="monster">Monster.</param>
        /// <returns>True, if hero is killed; otherwise false.</returns>
        private static bool MonsterAttack(Hero hero, Monster monster)
        {
            int nextAttack = monster.CalculateAttack();
            int damage = hero.CalculateDamage(nextAttack);
            hero._health = Math.Max(hero._health - damage, 0);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Monster attacks for {nextAttack} HP. Hero is left with {hero._health} HP.");
            Console.ResetColor();

            if (hero._health == 0)
            {
                Console.WriteLine("Hero is dead. OH NO!");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// Hero encounters a chance to find a potion.
        /// </summary>
        /// <param name="hero">Hero.</param>
        /// <param name="chance">Chance to found a potion.</param>
        private static void PotionChance(Hero hero, double chance)
        {
            Random r = new Random(Environment.TickCount);
            if (r.NextDouble() <= chance)
            {
                Potion potion = new Potion();
                hero.DrinkPotion(potion);

                Console.WriteLine($"Hero founds {potion._name} and drinks it. Hero's health is {hero._health} HP.");
                Console.ReadKey();
            }
        }

    }
}