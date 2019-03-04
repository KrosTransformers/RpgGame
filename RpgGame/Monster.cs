using System;

namespace RpgGame
{

    /// <summary>
    /// Class representing monster.
    /// </summary>
    class Monster
    {

        /// <summary>
        /// Name of the monster.
        /// </summary>
        private string _name = "Sully the Fluffer";

        /// <summary>
        /// Type of the monster.
        /// </summary>
        private string _type = "Closet monster";

        /// <summary>
        /// Current health.
        /// </summary>
        private int _health = 500;

        /// <summary>
        /// Max health.
        /// </summary>
        private int _maxHealth = 500;

        /// <summary>
        /// Minimum amount of attack this monster can inflict.
        /// </summary>
        private int _minAttack = 54;

        /// <summary>
        /// Maximum amount of attack this monster can inflict.
        /// </summary>
        private int _maxAttack = 86;

        /// <summary>
        /// Amount of experience point rewarded to hero for defeating this monster.
        /// </summary>
        private int _rewardXp = 120;

        /// <summary>
        /// Amount of gold provided to hero for defeating this monster.
        /// </summary>
        private int _rewardGold = 500;

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
                  $"Health:     {_health} HP\n" +
                  $"Max health: {_maxHealth} HP\n" +
                  $"Min attack: {_minAttack}\n" +
                  $"Max attack: {_maxAttack}\n" +
                  $"Reward:     {_rewardXp} XP\n" +
                  $"Reward:     {_rewardGold} gold\n";
        }

    }

}