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
        private string _type = "Closer monster";

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

    }

}