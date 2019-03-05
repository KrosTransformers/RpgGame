using System;

namespace RpgGame
{

    /// <summary>
    /// Class representing monster.
    /// </summary>
    class Monster
    {

        #region Attributes       

        /// <summary>
        /// Max health.
        /// </summary>
        private int _maxHealth;

        /// <summary>
        /// Minimum amount of attack this monster can inflict.
        /// </summary>
        private int _minAttack;

        /// <summary>
        /// Maximum amount of attack this monster can inflict.
        /// </summary>
        private int _maxAttack;

        #endregion

        #region Properties

        /// <summary>
        /// Name of the monster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the monster.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Current health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Checks whether monster is dead.
        /// </summary>
        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }

        /// <summary>
        /// Amount of experience point rewarded to hero for defeating this monster.
        /// </summary>
        public int RewardXp { get; private set; }

        /// <summary>
        /// Amount of gold provided to hero for defeating this monster.
        /// </summary>
        public int RewardGold { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Ctor.
        /// </summary>
        public Monster()
        {
            Name = "Sully the Fluffer";
            Type = "Closet monster";
            Health = 200;
            _maxHealth = 200;
            _minAttack = 12;
            _maxAttack = 25;
            RewardXp = 120;
            RewardGold = 500;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="maxHealth">Max health.</param>
        /// <param name="minAttack">Minimum amount of attack this monster can inflict.</param>
        /// <param name="maxAttack">Maximum amount of attack this monster can inflict.</param>
        public Monster(int maxHealth, int minAttack, int maxAttack):this()
        {
            Health = maxHealth;
            _maxHealth = maxHealth;
            _minAttack = minAttack;
            _maxAttack = maxAttack;
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
            return r.Next(_minAttack, _maxAttack + 1);
        }

        /// <summary>
        /// Returns monster's description.
        /// </summary>
        /// <returns>Monster's description.</returns>
        public string DescribeMe()
        {
            return "Monster\n" +
                  $"Name:       {Name}\n" +
                  $"Type:       {Type}\n" +
                  $"Health:     {Health} HP\n" +
                  $"Max health: {_maxHealth} HP\n" +
                  $"Min attack: {_minAttack}\n" +
                  $"Max attack: {_maxAttack}\n" +
                  $"Reward:     {RewardXp} XP\n" +
                  $"Reward:     {RewardGold} gold\n";
        }

        #endregion

    }

}