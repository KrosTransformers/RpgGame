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
                    if (hero.CanLevelUp)
                    {
                        Console.WriteLine("Hero levels up!!!");                        
                        hero.LevelUp();
                        Console.WriteLine(hero.CurrentHeroStatus());
                        Console.ReadKey();
                    }

                    monster = new Monster();
                    Console.WriteLine("Hero encounters another monster!!!");
                    Console.ReadKey();
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
            monster.Health = Math.Max(monster.Health - nextAttack, 0);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Hero attacks for {nextAttack} HP. Monster is left with {monster.Health} HP.");
            Console.ResetColor();

            if (monster.IsDead)
            {
                hero.XP += monster.RewardXp;
                hero.Gold += monster.RewardGold;

                Console.WriteLine($"Monster is dead. YAY!\nHero recieves {monster.RewardXp} XP and {monster.RewardGold} gold.");
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
            hero.Health = Math.Max(hero.Health - damage, 0);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Monster attacks for {nextAttack} HP. Hero is left with {hero.Health} HP.");
            Console.ResetColor();

            if (hero.IsDead)
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

                Console.WriteLine($"Hero founds {potion.Name} and drinks it. Hero's health is {hero.Health} HP.");
                Console.ReadKey();
            }
        }

    }
}