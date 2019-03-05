using System;

namespace RpgGame
{

    /// <summary>
    /// Core class organising battles between hero and enemies.
    /// </summary>
    static class BattleMaster
    {

        #region Constants for random generation

        private const double POTION_CHANCE = 0.25;
        private const double SMALL_POTION_CHANCE = 0.3;
        private const double LARGE_POTION_CHANCE = 0.1;
        private const int CORE_MONSTER_HEALTH = 200;
        private const double MONSTER_HEALTH_MULTIPLIER = 0.5;
        private const int MONSTER_MIN_ATTACK_MIN_MULTIPLIER = 6;
        private const int MONSTER_MIN_ATTACK_MAX_MULTIPLIER = 7;
        private const double MONSTER_MAX_ATTACK_MULTIPLIER = 1.5;
        
        private static string[] MONSTER_NAMES = { "Sully the Fluffer", "Clayton", "Dave", "Ursula", "Bowser",
                                                  "Ganondorf", "Sephiroth", "Arthas", "Goro", "Gru" };
        private static string[] MONSTER_TYPES = { "Closet monster", "Goblin king", "Balrog", "Eye stabber", "Fire elemental",
                                                  "Water elemental", "Black mage", "Lich king", "Vampire", "Minotaur" };

        #endregion

        /// <summary>
        /// Creates monster appropriate to hero's level.
        /// </summary>
        /// <param name="heroLevel">Hero's level.</param>
        /// <returns></returns>
        static Monster CreateMonster(int heroLevel)
        {
            Random r = new Random(Environment.TickCount);

            int maxHealth = (int)(CORE_MONSTER_HEALTH * heroLevel * MONSTER_HEALTH_MULTIPLIER);
            int minAttack = r.Next(MONSTER_MIN_ATTACK_MIN_MULTIPLIER * heroLevel, MONSTER_MIN_ATTACK_MAX_MULTIPLIER * heroLevel);
            int maxAttack = (int)(MONSTER_MAX_ATTACK_MULTIPLIER * minAttack);

            Monster monster = new Monster(maxHealth, minAttack, maxAttack);
            monster.Name = MONSTER_NAMES[r.Next(MONSTER_NAMES.Length)];
            monster.Type = MONSTER_TYPES[r.Next(MONSTER_TYPES.Length)];

            return monster;
        }

        /// <summary>
        /// Runs a battle between hero and monster.
        /// </summary>
        /// <param name="hero">Hero.</param>
        /// <param name="monster">Monster.</param>
        /// <returns>True, if hero defeated the monster; otherwise false.</returns>
        static bool BattleMonster(Hero hero, Monster monster)
        {
            while (true)
            {
                if (HeroAttack(hero, monster))
                {
                    hero.XP += monster.RewardXp;
                    hero.Gold += monster.RewardGold;

                    Console.WriteLine($"\nMonster is dead. YAY!\nHero recieves {monster.RewardXp} XP and {monster.RewardGold} gold.\n");
                    Console.ReadKey();

                    return true;
                }
                else
                {
                    Console.ReadKey();
                }

                if (MonsterAttack(hero, monster))
                {
                    Console.WriteLine("\nHero is dead. OH NO!");
                    Console.ReadKey();

                    return false;
                }
                else
                {
                    Console.ReadKey();
                }

                PotionChance(hero, POTION_CHANCE);
            }
        }

        /// <summary>
        /// Starts hero's glorious battle campaign.
        /// </summary>
        /// <param name="hero">Hero.</param>
        public static void StartCampaign(Hero hero)
        {
            Console.WriteLine("Hero enters the dungeon.");
            Console.ReadKey();

            while (true)
            {
                Monster monster = CreateMonster(hero.Level);
                Console.WriteLine($"\nHero encounters {monster.Name}, the {monster.Type}!!!\n");
                Console.ReadKey();

                if (BattleMonster(hero, monster))
                {
                    if (hero.CanLevelUp)
                    {
                        Console.WriteLine("Hero levels up!!!");
                        hero.LevelUp();
                        Console.WriteLine(hero.CurrentHeroStatus());
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("GAME OVER\n");
                    Console.ReadKey();
                    break;
                }
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

            return monster.IsDead;
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
            Console.WriteLine($"Monster attacks for {damage} HP. Hero is left with {hero.Health} HP.");
            Console.ResetColor();

            return hero.IsDead;
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
                Potion potion;

                double potionTypeChance = r.NextDouble();
                if (potionTypeChance <= SMALL_POTION_CHANCE)
                {
                    potion = new Potion("Small potion", 20);
                }
                else if (potionTypeChance <= (1 - LARGE_POTION_CHANCE))
                {
                    potion = new Potion("Medium potion", 50);
                }
                else
                {
                    potion = new Potion("Super potion", 100);
                }
                hero.DrinkPotion(potion);

                Console.WriteLine($"Hero founds {potion.Name} and drinks it. Hero's health is {hero.Health} HP.");
                Console.ReadKey();
            }
        }

    }

}