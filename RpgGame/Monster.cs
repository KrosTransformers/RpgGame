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
        private string _name = "Sully the Fluffer";

        /// <summary>
        /// Type of the monster.
        /// </summary>
        private string _type = "Closet monster";

        /// <summary>
        /// Max health.
        /// </summary>
        private int _maxHealth = 200;

        /// <summary>
        /// Minimum amount of attack this monster can inflict.
        /// </summary>
        private int _minAttack = 12;

        /// <summary>
        /// Maximum amount of attack this monster can inflict.
        /// </summary>
        private int _maxAttack = 25;

        #endregion

        #region Properties

        /// <summary>
        /// Current health.
        /// </summary>
        public int Health { get; set; } = 200;

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
        public int RewardXp { get; } = 120;

        /// <summary>
        /// Amount of gold provided to hero for defeating this monster.
        /// </summary>
        public int RewardGold { get; } = 500;

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