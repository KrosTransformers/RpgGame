using System;

namespace RpgGame
{
    
    /// <summary>
    /// Class representing hero.
    /// </summary>
    class Hero
    {

        #region Constants

        private const double NEXT_LVL_XP_MULTIPLIER = 2.2;
        private const int MIN_HEALTH_ADDITION = 5;
        private const int MAX_HEALTH_ADDITION = 15;
        private const int MIN_ATTACK_ADDITION = 4;
        private const int MAX_ATTACK_ADDITION = 9;
        private const double MAX_ATTACK_MULTIPLIER = 1.67;
        private const int MIN_DEFENSE_ADDITION = 3;
        private const int MAX_DEFENSE_ADDITION = 7;
        private const double EVADE_ADDITION = 0.005;
        private const double LUCK_ADDITION = 0.02;

        #endregion

        #region Attributes

        /// <summary>
        /// Hero's name.
        /// </summary>
        private string _name;

        /// <summary>
        /// Hero's race.
        /// </summary>
        private eHeroRace _race;

        /// <summary>
        /// Hero's class.
        /// </summary>
        private eHeroClass _class;

        /// <summary>
        /// Level.
        /// </summary>
        private int _level;        

        /// <summary>
        /// Maximum health.
        /// </summary>
        private int _maxHealth;

        /// <summary>
        /// XP amount needed to achieve next level.
        /// </summary>
        private int _nextLevelXp;

        /// <summary>
        /// Minimum amount of attack this monster can inflict.
        /// </summary>
        private int _minAttack;

        /// <summary>
        /// Maximum amount of attack this monster can inflict.
        /// </summary>
        private int _maxAttack;

        /// <summary>
        /// Strength of defense.
        /// </summary>
        private int _defense;

        /// <summary>
        /// Percentual chance to evade incoming attack.
        /// </summary>
        private double _evade;

        /// <summary>
        /// Percentual chance to score critical hit.
        /// </summary>
        private double _luck;

        #endregion

        #region Properties

        /// <summary>
        /// Current health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Checks whether hero is dead.
        /// </summary>
        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }

        /// <summary>
        /// Experience points.
        /// </summary>
        public int XP { get; set; }

        /// <summary>
        /// Checks whether hero can level up.
        /// </summary>
        public bool CanLevelUp
        {
            get
            {
                return XP >= _nextLevelXp;
            }
        }

        /// <summary>
        /// Gold.
        /// </summary>
        public int Gold { get; set; } = 250;

        #endregion

        #region Constructors

        /// <summary>
        /// Ctor.
        /// </summary>
        public Hero()
        {
            _name = "Lothar Lightbringer";
            _race = eHeroRace.Human;
            _class = eHeroClass.Paladin;
            _level = 2;
            Health = 100;
            _maxHealth = 100;
            XP = 80;
            _nextLevelXp = 100;
            Gold = 250;
            _minAttack = 12;
            _maxAttack = 20;
            _defense = 5;
            _evade = 0.025;
            _luck = 0.05;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns power of next attack.
        /// </summary>
        /// <returns>Power of next attack.</returns>
        public int CalculateAttack()
        {
            Random r = new Random(Environment.TickCount);
            return (int)(r.Next(_minAttack, _maxAttack + 1) * (r.NextDouble() <= _luck ? 1.2 : 1.0));
        }

        /// <summary>
        /// Calculates damage the hero will take from attack.
        /// </summary>
        /// <param name="attackPower">Power of attack.</param>
        /// <returns>Damage the hero will take; 0 if hero evaded the attack.</returns>
        public int CalculateDamage(int attackPower)
        {
            Random r = new Random(Environment.TickCount);

            if (r.NextDouble() <= _evade)
            {
                // evaded attack
                return 0;
            }
            else
            {
                return attackPower - _defense;
            }
        }

        /// <summary>
        /// Restores heroe's HP.
        /// </summary>
        /// <param name="potion">Health potion.</param>
        public void DrinkPotion(Potion potion)
        {
            Health = Math.Min(Health + potion.MaxHealedHp, _maxHealth);
        }

        /// <summary>
        /// Levels up hero.
        /// </summary>
        public void LevelUp()
        {
            Random r = new Random(Environment.TickCount);

            while (CanLevelUp)
            {
                _level++;
                _nextLevelXp = (int)(_nextLevelXp * NEXT_LVL_XP_MULTIPLIER);

                _maxHealth = (int)(_maxHealth * (1 + r.Next(MIN_HEALTH_ADDITION, MAX_HEALTH_ADDITION) / 100.0));
                _minAttack += r.Next(MIN_ATTACK_ADDITION, MAX_ATTACK_ADDITION);
                _maxAttack = (int)(_minAttack * MAX_ATTACK_MULTIPLIER);
                _defense += r.Next(MIN_DEFENSE_ADDITION, MAX_DEFENSE_ADDITION);
                _evade = Math.Min(0.9, _evade + EVADE_ADDITION);
                _luck = Math.Min(1.0, _luck + LUCK_ADDITION);
            }
        }

        /// <summary>
        /// Returns hero's description.
        /// </summary>
        /// <returns>Hero's description.</returns>
        public string DescribeMe()
        {
            return "Hero\n" +
                  $"Name:       {_name}\n" +
                  $"Race:       {_race}\n" +
                  $"Class:      {_class}\n" +
                  $"Level:      {_level}\n" +
                  $"Health:     {Health} HP\n" +
                  $"Gold:       {Gold}\n" +
                  $"Min attack: {_minAttack}\n" +
                  $"Max attack: {_maxAttack}\n" +
                  $"Defense:    {_defense}\n" +
                  $"Evade:      {_evade:0.00%}\n" +
                  $"Luck:       {_luck:0.00%}\n";
        }

        /// <summary>
        /// Returns hero's simple current status.
        /// </summary>
        /// <returns>Hero's current status.</returns>
        public string CurrentHeroStatus()
        {
            return $"{_name} is level {_level} {_race} {_class} with {Health}/{_maxHealth} HP, {_minAttack}-{_maxAttack} ATK, {_defense} DEF, {_luck:0.00%} LCK and {_evade:0.00%} EVA.";
        }

        #endregion

    }

    /// <summary>
    /// Enumeration of hero races.
    /// </summary>
    enum eHeroRace
    {
        None = 0,
        Human = 1,
        Dwarf = 2,
        Elf = 3
    }

    /// <summary>
    /// Enumeration of hero class.
    /// </summary>
    enum eHeroClass
    {
        None = 0,
        Paladin = 1,
        Thief = 2,
        Mage = 3
    }

}