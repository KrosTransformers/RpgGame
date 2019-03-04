namespace RpgGame
{

    /// <summary>
    /// Class representing potion to restore health.
    /// </summary>
    class Potion
    {

        #region Properties

        /// <summary>
        /// Name of the potion.
        /// </summary>
        public string Name { get; private set; } = "Medium potion";

        /// <summary>
        /// Maximum amount of HP this potion could restore.
        /// </summary>
        public int MaxHealedHp { get; private set; } = 55;

        #endregion

        #region Methods

        /// <summary>
        /// Returns potion's description.
        /// </summary>
        /// <returns>Potion's description.</returns>
        public string DescribeMe()
        {
            return "Potion\n" +
                  $"Name:  {Name}\n" +
                  $"Heals: {MaxHealedHp} HP\n";
        }

        #endregion

    }

}