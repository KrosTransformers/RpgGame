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
        /// Name of the monster.
        /// </summary>
        private string _name;

        /// <summary>
        /// Type of the monster.
        /// </summary>
        private string _type;

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
            _name = "Sully the Fluffer";
            _type = "Closet monster";
            Health = 200;
            _maxHealth = 200;
            _minAttack = 12;
            _maxAttack = 25;
            RewardXp = 120;
            RewardGold = 500;
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
                  $"Name:       {_name}\n" +
                  $"Type:       {_type}\n" +
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